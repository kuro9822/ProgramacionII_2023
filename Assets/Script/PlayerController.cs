using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    public Transform groundCheckCenter, groundCheckLeft, groundCheckRight;
    public float speedPlayer = 10, jumpPlayer = 10;
    public Rigidbody2D rb;
    public bool isGround;
    public LayerMask ground;
    public float checkRadius = .2f;
    public float lowMultiplierJump = 2;
    public float fallMultiplierJump = 2.5f;
    public bool canMove = true;
    public float preBuffTime = .2f;
    private float actualPreBuff;
    public bool prebuff;
    public bool jumping;
    public bool coyoteJump;
    public float coyoteTime = .2f;
    public float actualCoyoteTime;

    private void Start()
    {
        actualPreBuff = preBuffTime;
        actualCoyoteTime = coyoteTime;
    }

    // Update is called once per frame
    void Update()
    {
        isGround = IsGrounded(groundCheckCenter)
                   || IsGrounded(groundCheckLeft) 
                   || IsGrounded(groundCheckRight);

        if (isGround)
        {
            jumping = false;
            coyoteJump = false;
        }

        if (actualCoyoteTime < coyoteTime)
        {
            coyoteJump = true;
            actualCoyoteTime += 1 * Time.deltaTime;
            if (actualCoyoteTime >= coyoteTime)
            {
                jumping = true;
                coyoteJump = false;
            }
        }

        if (actualPreBuff < preBuffTime)
        {
            actualPreBuff += 1 * Time.deltaTime;
            prebuff = true;
            if (actualPreBuff >= preBuffTime)
            {
                prebuff = false;
            }
        }

        if (rb.velocity.y < 0 && !jumping)
        {
            actualCoyoteTime = 0;
        }

        if (jumping)
        {
            actualCoyoteTime = coyoteTime;
        }

        if (canMove)
        {
            float x = Input.GetAxis("Horizontal");
            rb.velocity = new Vector2(x * speedPlayer, rb.velocity.y);
            if (Input.GetButtonDown("Jump"))
            {
                actualPreBuff = 0;
            }

            if ((prebuff && isGround) || coyoteJump && prebuff)
            {
                Jump();
            }
        }
       

        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * (Physics2D.gravity.y * ((fallMultiplierJump-1) * Time.deltaTime));
        }
        else if(rb.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            rb.velocity += Vector2.up * (Physics2D.gravity.y * ((lowMultiplierJump-1) * Time.deltaTime));
        }
    }

    public void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, 0);
        rb.velocity += Vector2.up * jumpPlayer;
        jumping = true;
    }
    bool IsGrounded(Transform check)
    {
        return Physics2D.OverlapCircle(check.position, checkRadius, ground);
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(groundCheckCenter.position, checkRadius);
        Gizmos.DrawWireSphere(groundCheckLeft.position, checkRadius);
        Gizmos.DrawWireSphere(groundCheckRight.position, checkRadius);
    }
}
