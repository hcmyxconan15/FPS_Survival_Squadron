using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class LoadMap : MonoBehaviour
{
    public void InstantiateEnemy(string nameFile)
    {
        EnititySave[] enititySaves = HelperStore.ReadData<EnititySave>(nameFile);
        for(int i = 0; i < enititySaves.Length; i++)
        {
            if(enititySaves[i].type == 1)
            {
                PhotonNetwork.Instantiate("Zombie", enititySaves[i].GetPosition(), Quaternion.identity);
            }
        }
    }
}
