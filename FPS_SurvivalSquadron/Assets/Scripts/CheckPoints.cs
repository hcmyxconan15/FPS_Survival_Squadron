using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoints : MonoBehaviour
{
    public static int PointTeamA;
    public static int PointTeamB;
    private void Awake()
    {
        PointTeamA = 0;
        PointTeamB = 0;
    }
}
