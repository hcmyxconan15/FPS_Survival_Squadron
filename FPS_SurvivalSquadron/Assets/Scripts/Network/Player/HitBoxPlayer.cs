using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class HitBoxPlayer : HitBox
{
    [SerializeField] PhotonView pv => GetComponent<PhotonView>();
    public override void OnRaycastHit(RayCastWeapon weapon, Vector3 diretion)
    {
        health.TakeDamage(weapon.damage, diretion);
    }



}
