using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using Photon.Pun;
[CreateAssetMenu(menuName = "Singleton/MasterManager")]
public class MasterManager : SingletonScriptableObject<MasterManager>
{
    [SerializeField]
    private List<NetworkPrefab> networkPrefabs = new List<NetworkPrefab>();

    public static GameObject NetworkInstantiate(GameObject obj, Vector3 position, Quaternion rotation)
    {
        if(Instance.networkPrefabs != null)
        {
            foreach (NetworkPrefab networkPrefab in Instance.networkPrefabs)
            {
                if (networkPrefab.Prefab == obj)
                {
                    GameObject result = PhotonNetwork.Instantiate("Player", position, rotation);
                    return result;
                }
            }
        }
        
        return null;
    }

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void PopulateNetworkPrefab()
    {
#if UNITY_EDITOR

        if (Instance == null) return;
        Instance.networkPrefabs.Clear();
        GameObject[] results = Resources.LoadAll<GameObject>("");
        MasterManager[] rresult1 = Resources.FindObjectsOfTypeAll<MasterManager>();
        for(int i = 0; i < results.Length; i++)
        {
            if(results[i].GetComponent<PhotonView>() != null)
            {
                string path = AssetDatabase.GetAssetPath(results[i]);
                Instance.networkPrefabs.Add(new NetworkPrefab(results[i], path));
            }
        }
#endif
    }
}
