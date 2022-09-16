using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantitePrefab : MonoBehaviour
{
    [SerializeField] GameObject prefab;
    void Start()
    {
        Instantite();
    }

    private void Instantite()
    {
        MasterManager.NetworkInstantiate(prefab, Vector3.zero, Quaternion.identity);
    }
}
