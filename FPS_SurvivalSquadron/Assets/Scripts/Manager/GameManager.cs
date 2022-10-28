using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using UnityEngine.UI;

public class GameManager : SingletonMonoBehaviour<GameManager>
{
    private void Start()
    {
        //InstanceUIManager();
        if (UIManager.HasInstance)
        {
            UIManager.Instance.ShowNotify<NotifyLoading>();
            NotifyLoading scr = UIManager.Instance.GetExistNotify<NotifyLoading>();
            if (scr != null)
            {
                UIManager.Instance.ShowScreen<ScreenHome>();
            }
        }
    }

    //private GameObject InstanceUIManager()
    //{
    //    GameObject UIManager = Resources.Load("UI/Manager/UIManager") as GameObject;
    //    return UIManager;
    //}
}
