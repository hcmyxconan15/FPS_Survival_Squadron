using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseUIElement : MonoBehaviour
{
    protected CanvasGroup canvasGroup;
    protected UIType uiType = UIType.Unkow;
    protected bool isHide;
    protected bool isInited;

    public bool IsInited => isInited;
    public bool IsHide => isHide;
    public CanvasGroup CanvasGroup => canvasGroup;
    public UIType UIType => uiType;
    
    public virtual void Init()
    {
        this.isInited = true;
        if (!this.gameObject.GetComponent<CanvasGroup>())
        {
            this.gameObject.AddComponent<CanvasGroup>();
        }
        this.canvasGroup = this.gameObject.GetComponent<CanvasGroup>();
        this.gameObject.SetActive(true);
    }

    public virtual void Show(object data)
    {
        this.gameObject.SetActive(true);
        this.isHide = false;
        SetActiveCanvasGroup(true);
    }

    public virtual void Hide()             
    {
        this.isHide = true;
        SetActiveCanvasGroup(false);
    }

    public virtual void OnUIClick()
    {
        if(AudioManager.HasInstance)
        {
            AudioManager.Instance.PlaySoundEffect("UIClick");
        }
    }

    public virtual void OnUIHover()
    {
        if (AudioManager.HasInstance)
        {
            AudioManager.Instance.PlaySoundEffect("UIHover");
        }
    }

    private void SetActiveCanvasGroup(bool isActive)
    {
        if(CanvasGroup != null)
        {
            canvasGroup.blocksRaycasts = isActive;
            CanvasGroup.alpha = isActive ? 1 : 0;
        }
    }


}
