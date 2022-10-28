using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupSetting : BasePopup
{
    public Slider musicVolume;
    public Slider effectVolume;
    AudioManager audioManager;
    public Toggle[] toggle;
    private int curIndex;
    private float curMusicVolume, cureffectVolume;

    private void Awake()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }

    private void Start()
    {
        CheckInit();
        LoadQuality();
        LoadVolume();
    }

    public override void Show(object data)
    {
        base.Show(data);
    }

    public override void Hide()
    {
        base.Hide();
    }


    public void OnClickCloseButton()
    {
        PopupPause popupPause = UIManager.Instance.GetExistPopup<PopupPause>();
        if (popupPause == null)
        {
            this.Hide();
        }
        else if(popupPause != null)
        {
            if (popupPause.IsHide == true)
            {
                this.Hide();
                popupPause.Show(this.gameObject);
            }
        }
    }

    private void CheckInit()
    {
        if (!PlayerPrefs.HasKey(CONSTANT.PP_EFFECTVOLUME))
        {
            PlayerPrefs.SetFloat(CONSTANT.PP_EFFECTVOLUME, CONSTANT.DEFAULT_EFFECTVOLUME);
        }
        if (!PlayerPrefs.HasKey(CONSTANT.PP_MUSICVOLUME))
        {
            PlayerPrefs.SetFloat(CONSTANT.PP_MUSICVOLUME, CONSTANT.DEFAULT_MUSICVOLUME);
        }
        if (!PlayerPrefs.HasKey(CONSTANT.PP_QUALITY))
        {
            PlayerPrefs.SetInt(CONSTANT.PP_QUALITY, CONSTANT.DEFAULT_QUALITY);
            toggle[PlayerPrefs.GetInt(CONSTANT.PP_QUALITY)].isOn = true;
        }
    }

    public void ChangeMusicVolume(float value)
    {
        foreach (var music in audioManager.soundsMusic)
        {
            music.source.volume = value;
        }
        curMusicVolume = value;
    }    

    public void ChangeEffectVolume(float value)
    {
        foreach (var effect in audioManager.soundsEffect)
        {
            effect.source.volume = value;
        }
        cureffectVolume = value;
    }

    private void LoadVolume()
    {
        musicVolume.value = PlayerPrefs.GetFloat(CONSTANT.PP_MUSICVOLUME);
        effectVolume.value = PlayerPrefs.GetFloat(CONSTANT.PP_EFFECTVOLUME);
    }

    public void OnClickGraphicChange(int Level)
    {
        curIndex = Level;
    }
    public void ApplySettiing()
    {
        var music = PlayerPrefs.GetFloat(CONSTANT.PP_MUSICVOLUME);
        var effect = PlayerPrefs.GetFloat(CONSTANT.PP_MUSICVOLUME);
        var index = PlayerPrefs.GetInt(CONSTANT.PP_QUALITY);
        if(curMusicVolume != music)
        {
            PlayerPrefs.SetFloat(CONSTANT.PP_MUSICVOLUME, curMusicVolume);
        }
        if(cureffectVolume != effect)
        {
            PlayerPrefs.SetFloat(CONSTANT.PP_EFFECTVOLUME, cureffectVolume);
        }
        if(curIndex != index)
        {
            QualitySettings.SetQualityLevel(curIndex);
            PlayerPrefs.SetInt(CONSTANT.PP_QUALITY, curIndex);
        }
    }

    private void LoadQuality()
    {
        QualitySettings.SetQualityLevel(PlayerPrefs.GetInt(CONSTANT.PP_QUALITY));
        toggle[PlayerPrefs.GetInt(CONSTANT.PP_QUALITY)].isOn = true;
    }
}
