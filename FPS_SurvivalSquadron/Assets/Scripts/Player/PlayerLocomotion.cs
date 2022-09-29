using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLocomotion : MonoBehaviour
{
    #region Movement
    [Header("Player Movement")]
    private Animator animator;
    private CharacterController cc;
    private Vector2 input;
    #endregion
    #region Gravity and jum and StepDown
    [Header("Gravity and jum and StepDown")]
    public float jumHeight;
    public float gravity;
    public float stepDown;
    public float airControl;
    public float jumDamp;
    public float groundSpeed;
    public float pushPower;

    private Vector3 velocity;
    private Vector3 rootMotion;
    private bool isJumping;
    #endregion

    #region Sprinting
    [Header("Sprinting")]
    public Animator rigController;
    private int isSprintingParam = Animator.StringToHash("isSprinting");

    #endregion




    private void Start()
    {
        animator = GetComponent<Animator>();
        cc = GetComponent<CharacterController>();
    }
    private void Update()
    {
        Move();
    }
    virtual protected void Move()
    {
        input.x = Input.GetAxis("Horizontal");
        input.y = Input.GetAxis("Vertical");

        animator.SetFloat("InputX", input.x);
        animator.SetFloat("InputY", input.y);

        updateSprinting();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    private void updateSprinting()
    {
        bool isSprinting = Input.GetKey(KeyCode.LeftShift);
        animator.SetBool(isSprintingParam, isSprinting);
        rigController.SetBool(isSprintingParam, isSprinting);
    }

    private void OnAnimatorMove()
    {
        rootMotion += animator.deltaPosition;
    }

    virtual protected void FixedUpdate()
    {
        if (isJumping) // is inAir state
        {
            UpdateInAir();
        }
        else // is Grounded state
        {
            UpdateOnGround();
        }
    }

    private void UpdateOnGround()
    {
        Vector3 stepForwardAmount = rootMotion * groundSpeed;
        Vector3 StepDownAmount = Vector3.down * stepDown;
        cc.Move(stepForwardAmount + StepDownAmount);
        rootMotion = Vector3.zero;

        if (!cc.isGrounded)
        {
            SetInAir(0);
        }
    }

    private void UpdateInAir()
    {
        velocity.y -= gravity * Time.fixedDeltaTime;
        Vector3 displacement = velocity * Time.fixedDeltaTime;
        displacement += CalcualteAirControl();
        cc.Move(displacement);
        isJumping = !cc.isGrounded;
        rootMotion = Vector3.zero;
        animator.SetBool("isJumping", isJumping);
    }

    Vector3 CalcualteAirControl()
    {
        return ((transform.forward * input.y) + (transform.right * input.x)) * (airControl / 100);
    }

    private void Jump()
    {
        if (!isJumping)
        {
            float jumVelocity = Mathf.Sqrt(2 * gravity * jumHeight);
            SetInAir(jumVelocity);
        }
    }

    private void SetInAir(float jumVelocity)
    {
        isJumping = true;
        velocity = animator.velocity * jumDamp * groundSpeed;
        velocity.y = jumVelocity;
        animator.SetBool("isJumping", true);
    }
    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody body = hit.collider.attachedRigidbody;

        // no rigidbody
        if (body == null || body.isKinematic)
            return;

        // We dont want to push objects below us
        if (hit.moveDirection.y < -0.3f)
            return;

        // Calculate push direction from move direction,
        // we only push objects to the sides never up and down
        Vector3 pushDir = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);

        // If you know how fast your character is trying to move,
        // then you can also multiply the push velocity by that.

        // Apply the push
        body.velocity = pushDir * pushPower;
    }
}
