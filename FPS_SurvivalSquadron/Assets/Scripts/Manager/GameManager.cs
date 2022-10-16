using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager>
{
    [Header("CanvasGroup")]
    public CanvasGroup Loading;
    public CanvasGroup Home;
    public CanvasGroup Setting;
    public CanvasGroup SelectionMap;
    public CanvasGroup About;


    private void Start()
    {
        if(UIManager.HasInstance)
        {
            UIManager.Instance.ShowScreen<ScreenHome>();
        }
    }


    public void SetCanvas(CanvasGroup canvas, bool t)
    {
        canvas.alpha = t ? 1 : 0;
        canvas.blocksRaycasts = t;
        canvas.interactable = t;
    }




    public void OnClickQuitButton()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }
}
