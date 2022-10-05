using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Hashtable = ExitGames.Client.Photon.Hashtable;
using Photon.Realtime;

public class SwitchWeapon : MonoBehaviourPunCallbacks
{
    [SerializeField] private ActiveWeaponNetwork activeWeapon;
    [SerializeField] private PhotonView pv;
    private void Update()
    {
        Switch();
    }
    public void Switch()
    {
        if (pv.IsMine)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                Hashtable hash = new Hashtable();
                int itemIndex = (int)ActiveWeapon.WeaponSlot.Primary;
                hash.Add("itemIndex", itemIndex);
                PhotonNetwork.LocalPlayer.SetCustomProperties(hash);
                Debug.Log("1");
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                Hashtable hash = new Hashtable();
                int itemIndex = (int)ActiveWeapon.WeaponSlot.Secondary;
                hash.Add("itemIndex", itemIndex);
                PhotonNetwork.LocalPlayer.SetCustomProperties(hash);
                Debug.Log("2");
            }
        }
        
    }
    public override void OnPlayerPropertiesUpdate(Player targetPlayer, Hashtable changedProps)
    {
        if(!pv.IsMine && targetPlayer  == pv.Owner)
        {
            int index = (int)changedProps["itemIndex"];
            activeWeapon.SetActiveWeapon((ActiveWeapon.WeaponSlot)index);
            Debug.Log((ActiveWeapon.WeaponSlot)index);
        }
    }
}
