using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NotifyLoadingPlayGame : BaseNotify
{
    public Slider slider;
    public float time = 3f;
    float speed;
    //public bool isLoading = true;

    public override void Hide()
    {
        base.Hide();
    }

    public override void Init()
    {
        base.Init();
    }

    public override void Show(object data)
    {
        base.Show(data);
    }

    private void Start()
    {
        speed = time;
    }

    private void Update()
    {
        AnimationLoading();
    }

    public void AnimationLoading()
    {
        time -= Time.deltaTime;
        slider.value = 1 - time / speed;
        if (slider.value == 1)
        {
            gameObject.SetActive(false);
            slider.value = 0;
            time = speed;
        }
    }
}
