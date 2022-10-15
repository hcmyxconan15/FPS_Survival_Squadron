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
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
