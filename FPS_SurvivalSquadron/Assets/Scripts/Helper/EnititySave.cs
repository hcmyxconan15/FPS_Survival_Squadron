using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnititySave
{
    public int type;
    public float x;
    public float y;
    public float z;
    public EnititySave(ZombieType _type, Vector3 position)
    {
        type = (int) _type;
        x = position.x;
        y = position.y;
        z = position.z;
    }
}
