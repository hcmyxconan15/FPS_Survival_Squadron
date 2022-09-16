using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class NetworkPrefab
{
    public GameObject Prefab;
    public string Path;

    public NetworkPrefab(GameObject _prefab, string _path)
    {
        Prefab = _prefab;
        Path = _path;
    }
}
