using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupSetting : BasePopup
{
    public Slider musicVolume;
    public Slider effectVolume;
    AudioManager audioManager;

    private void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
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
        this.Hide();
    }

    public void ChangeMusicVolume()
    {
       audioManager.sounds[0].source.volume = musicVolume.value;
    }    
    
    public void ChangeEffectVolume()
    {
      for(int i = 1; i < audioManager.sounds.Length;i++)
      {
            audioManager.sounds[i].source.volume = effectVolume.value;
      }
    }

    public void OnClickGraphicChange(int Level)
    {
        QualitySettings.SetQualityLevel(Level);
    }
}
