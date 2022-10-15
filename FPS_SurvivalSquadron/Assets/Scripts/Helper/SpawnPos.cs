using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPos : MonoBehaviour
{
    public ZombieType type;
    public Transform transform => GetComponent<Transform>();

}
