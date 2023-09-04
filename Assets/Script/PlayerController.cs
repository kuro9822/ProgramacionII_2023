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

// Update is called once per frame
    void Update()
    {
        isGround = IsGrounded(groundCheckCenter)
                   || IsGrounded(groundCheckLeft) 
                   || IsGrounded(groundCheckRight);
        if (canMove)
        {
            float x = Input.GetAxis("Horizontal");
            rb.velocity = new Vector2(x * speedPlayer, rb.velocity.y);
            if (Input.GetButtonDown("Jump") && isGround)
            {
                rb.velocity = new Vector2(rb.velocity.x, 0);
                rb.velocity += Vector2.up * jumpPlayer;
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
