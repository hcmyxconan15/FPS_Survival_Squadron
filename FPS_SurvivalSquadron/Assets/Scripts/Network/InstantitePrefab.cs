using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Unity.VisualScripting;
using Invector.vCharacterController;
using UnityEngine.UI;

public class InstantitePrefab : MonoBehaviour
{
    [SerializeField] Transform transformParrent;
    private List<Transform> transforms;
    private GameObject goMine;
    public float time;
    private float timeReviese;
    public float timeGame = 300f;
    public Text text;
    public GameObject gos;
    public Text textTime;

    public Text TeamA;
    public Text TeamB;

    private void Awake()
    {
        transforms = transformParrent.GetComponentsInChildren<Transform>().ToListPooled();
        LoadSence();
    }
    private void Start()
    {
        Instantite();
        bool isdead = false;
        timeReviese = time;
        gos.SetActive(false);
    }
    public void LoadSence()
    {
        PhotonNetwork.CurrentRoom.IsOpen = false;
        PhotonNetwork.CurrentRoom.IsVisible = false;
        PopupSelect popupSelect = UIManager.Instance.GetExistPopup<PopupSelect>();
        popupSelect.LoadGame();
        UIManager.Instance.GetExistPopup<PopupNetwork>().Hide();
    }
    private void Instantite()
    {
        GameObject go = PhotonNetwork.Instantiate("Prefab/Player", RamdomPostion(), Quaternion.identity);
        if (PhotonNetwork.IsMasterClient)
            go.tag = "TeamA";
        else go.tag = "TeamB";
        if (go.GetComponent<PhotonView>().IsMine)
        {
            goMine = go;
        }

    }
    bool isdead;
    
    private void Update()
    {
        TeamA.text = CheckPoints.PointTeamA.ToString();
        TeamB.text = CheckPoints.PointTeamB.ToString();
        if (goMine != null)
        {
            if (goMine.GetComponent<vThirdPersonController>().isDead && !isdead)
            {
                
                isdead = true;
                gos.SetActive(true);
                StartCoroutine(Revirse());

            }
        }
        if(isdead == true)
        {
            timeReviese -= Time.deltaTime;
            textTime.text = ((int)timeReviese).ToString();
        }
        timeGame -= Time.deltaTime;
        if (timeGame > 0)
        {
            text.text = ((int)timeGame).ToString();
        }
        else
        {
            CheckPoints.PointTeamA = 0;
            CheckPoints.PointTeamB = 0;
            Photon.Pun.PhotonNetwork.Disconnect();
            Time.timeScale = 0;
            UIManager.Instance.GetExistScreen<ScreenPlayGame>().Hide();
            UIManager.Instance.GetExistNotify<NotifyVictory>().Show(this.gameObject);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;
        }

    }
    Vector3 RamdomPostion()
    {
        int ran = Random.RandomRange(0, transforms.Count);
        return transforms[ran].position;
    }
    IEnumerator Revirse()
    {
        yield return new WaitForSeconds(time);
        PhotonNetwork.Destroy(goMine);
        Instantite();
        isdead = false;
        timeReviese = time;
        gos.SetActive(false);
    }

}
