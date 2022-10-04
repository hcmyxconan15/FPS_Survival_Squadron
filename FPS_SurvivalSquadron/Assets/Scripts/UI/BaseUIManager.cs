using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseMenuUI : Singleton<BaseMenuUI>
{
    public void OnUIClick()
    {
        if (AudioManager.HasInstance)
        {
            AudioManager.Instance.PlaySound("UIClick");
        }
    }
    public void OnUIHover()
    {
        if (AudioManager.HasInstance)
        {
            AudioManager.Instance.PlaySound("UIHover");
        }
    }
}
