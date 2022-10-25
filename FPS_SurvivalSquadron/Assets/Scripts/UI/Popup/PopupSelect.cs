using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PopupSelect : BasePopup
{
    ScreenHome screenHome;

    public override void Hide()
    {
        base.Hide();
    }

    public override void Show(object data)
    {
        base.Show(data);
    }

    public override void Init()
    {
        base.Init();
    }

    // Start is called before the first frame update
    void Start()
    {
        screenHome = UIManager.Instance.GetExistScreen<ScreenHome>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void OnClickLoadScreenTutourial(string name)
    {
        SceneManager.LoadScene(name);
        this.Hide();
    }    
    
    public void OnClickLoadScreenSingle(string name)
    {
        SceneManager.LoadScene(name);
        this.Hide();

    }

    public void OnClickLoadScreenMultiPlayer(string name)
    {
        SceneManager.LoadScene(name);
        this.Hide();
    }

    public void OnClickBack()
    {
        this.Hide();
        screenHome.Show(this.gameObject);
    }


}
