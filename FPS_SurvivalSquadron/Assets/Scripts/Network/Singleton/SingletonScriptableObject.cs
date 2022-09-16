using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonScriptableObject<T> : ScriptableObject where T: ScriptableObject
{
    private static T _intance = null;

    public static T Instance
    {
        get
        {
            if(_intance == null)
            {
                T[] result = Resources.FindObjectsOfTypeAll<T>();
                if (result.Length == 0)
                {
                    return null;
                }
                if (result.Length > 1)
                {
                    return null;
                }
                _intance = result[0];
            }
            return _intance;
            
        }
    }
}
