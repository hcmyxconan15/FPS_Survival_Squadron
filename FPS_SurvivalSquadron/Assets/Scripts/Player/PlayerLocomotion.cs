using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLocomotion : MonoBehaviour
{
    #region Movement
    [Header("Player Movement")]
    Animator animator;
    Vector2 input;
    #endregion
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void FixedUpdate()
    {
        input.x = Input.GetAxis("Horizontal") ;
        input.y = Input.GetAxis("Vertical") ;

        animator.SetFloat("InputX", input.x);
        animator.SetFloat("InputY", input.y);
        
    }





}
