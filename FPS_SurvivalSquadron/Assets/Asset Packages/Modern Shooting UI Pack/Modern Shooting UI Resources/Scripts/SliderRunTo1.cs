using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SliderRunTo1 : MonoBehaviour
{
 
    public bool b=true;
	public Slider slider;
	public float speed=0.5f;

	public GameObject Loading;
	public GameObject Home;

	

	

  float time =0f;
  
  void Start()
  {
	  
	slider = GetComponent<Slider>();
  }
  
    void Update()
    {
		if(b)
		{
			time+=Time.deltaTime*speed;
			slider.value = time;
			
			if(time>1)
			{
				b=false;
				time=0;
			}

			if(slider.value == 1)
            {
				GameManager.Instance.SetCanvas(GameManager.Instance.Loading, false);
				GameManager.Instance.SetCanvas(GameManager.Instance.Home, true);
            }
		}
	}
	
	
}
