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
    public Vector3 GetPosition()
    {
        Vector3 vector3 = new Vector3(x, y, z);
        return vector3;
    }
}
