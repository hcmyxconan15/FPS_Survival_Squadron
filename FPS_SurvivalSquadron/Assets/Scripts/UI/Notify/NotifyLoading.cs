using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class NotifyLoading : BaseNotify
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

    private void AnimationLoading()
    {
        time -= Time.deltaTime;
        slider.value = 1 - time / speed;
        if (slider.value == 1)
        {
          gameObject.SetActive(false);
        }
    }

/*  private void AnimationLoading()
    {
        if (isLoading)
        {
            time += Time.deltaTime * speed;
            slider.value = time;
            if (time > 1)
            {
                isLoading = false;
                time = 0;
            }
            if (slider.value == 1)
            {
                Hide();
            }
        }
    }*/
}
