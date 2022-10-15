using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePosEnemy : MonoBehaviour
{
    SpawnPos[] spawnPoses => GetComponentsInChildren<SpawnPos>();
    private void Start()
    {
        SetPos(spawnPoses);
    }
    private void SetPos(SpawnPos[] _spawnPoseses)
    {
        EnititySave[] enititySaves = new EnititySave[_spawnPoseses.Length];
        if(enititySaves != null)
        {
            for (int i = 0; i < _spawnPoseses.Length; i++)
            {
                enititySaves[i] = new EnititySave(_spawnPoseses[i].type, _spawnPoseses[i].transform.position);
            }
        }
        HelperStore.WrriteData<EnititySave>("Map_1", enititySaves);  
    }
}
