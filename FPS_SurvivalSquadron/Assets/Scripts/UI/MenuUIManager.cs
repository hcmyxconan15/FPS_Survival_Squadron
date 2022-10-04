using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class MenuUIManager : BaseMenuUI
{
    public GameObject Loading;
    public GameObject Home;
    public GameObject Setting;
    public GameObject SelectionMap;

    private void Start()
    {
        Loading.SetActive(true);
        Home.SetActive(false);
        Setting.SetActive(false);
        SelectionMap.SetActive(false);
    }

    public void OnClickMapButton(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }


    public void OnClickMissionButton()
    {
        
        Home.SetActive(false);
        Setting.SetActive(false);
        SelectionMap.SetActive(true);
    }
    public void OnClickSettingButton()
    {
        Home.SetActive(false);
        Setting.SetActive(true);
        
    }
    public void OnClickBackButton()
    {
        Home.SetActive(true);
        Setting.SetActive(false);
    }
    public void OnClickQuitButton()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }

}
