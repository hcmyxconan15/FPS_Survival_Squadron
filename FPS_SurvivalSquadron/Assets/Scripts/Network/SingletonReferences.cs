using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonReferences : MonoBehaviour
{
    [SerializeField]
    MasterManager MasterManager;
    private void Awake()
    {
        DontDestroyOnLoad(this);
    }
    
}
