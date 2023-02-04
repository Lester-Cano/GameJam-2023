using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLifeCheck : MonoBehaviour
{
    public bool grounded = false;
    public float groundedCheckDistance, deadGround = 0;
    float bufferCheckDistance;


    Animator animator;


    void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    private void FixedUpdate()
    {
        isGrounded();

        if (isGrounded() == false)
        {
            Debug.Log(" not grounded");
            deadGround += Time.deltaTime;
            Death();

            bool Falling = animator.GetBool("Grounded");
            animator.SetBool("Grounded", false);

            transform.position += Vector3.down * 4.9f;

        }
        else
        {
            bool Falling = animator.GetBool("Grounded");
            animator.SetBool("Grounded", true);
        }
        
    }

    bool isGrounded()
    {
        Ray ray = new Ray(transform.position + Vector3.up * 0.25f, Vector3.down);

        if (Physics.Raycast(ray, out RaycastHit hit, 0.3f))
        {
            deadGround = 0;
            return true;
        }
        else
        {
            return false;
        }

    }

    void Death()
    {
        bool Dead = animator.GetBool("Dead");
    }
}
