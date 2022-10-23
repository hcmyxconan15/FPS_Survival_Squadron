using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PopupSelect : BasePopup
{

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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickLoadScreenTutourial(string name)
    {
        SceneManager.LoadScene(name);
    }    
    
    public void OnClickLoadScreenSingle(string name)
    {
        SceneManager.LoadScene(name);
    }    
    
    public void OnClickLoadScreenMultiPlayer(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void OnClickBack()
    {
        this.Hide();
    }


}
