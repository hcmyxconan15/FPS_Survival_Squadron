using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class MenuUIManager : BaseMenuUI
{
    
    

    private void Awake()
    {
        GameManager.Instance.SetCanvas(GameManager.Instance.Loading, true);
        GameManager.Instance.SetCanvas(GameManager.Instance.Home, false);
        GameManager.Instance.SetCanvas(GameManager.Instance.Setting, false);
        GameManager.Instance.SetCanvas(GameManager.Instance.SelectionMap, false);
        GameManager.Instance.SetCanvas(GameManager.Instance.About, false);

    }
    public void SetQuality(int qualityIndex)
    {
  
        QualitySettings.SetQualityLevel(qualityIndex);
    }
    public void OnClickMapButton(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }


    public void OnClickMissionButton()
    {

        
        GameManager.Instance.SetCanvas(GameManager.Instance.Home, false);
        GameManager.Instance.SetCanvas(GameManager.Instance.Setting, false);
        GameManager.Instance.SetCanvas(GameManager.Instance.SelectionMap, true);
    }

    public void OnClickAboutButton()
    {
        GameManager.Instance.SetCanvas(GameManager.Instance.Home, false);
        GameManager.Instance.SetCanvas(GameManager.Instance.About, true);

    }

    public void OnClickSettingButton()
    {
        
        GameManager.Instance.SetCanvas(GameManager.Instance.Home, false);
        GameManager.Instance.SetCanvas(GameManager.Instance.Setting, true);


    }
    public void OnClickBackButton()
    {
        
        GameManager.Instance.SetCanvas(GameManager.Instance.Home, true);
        GameManager.Instance.SetCanvas(GameManager.Instance.Setting, false);

    }
    public void OnClickQuitButton()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }

}
