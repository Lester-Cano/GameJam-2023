using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLifeCheck : MonoBehaviour
{
    public bool grounded = false, is_death;
    public float groundedCheckDistance;
    [SerializeField] int lives;

    [SerializeField] Canvas Canvasdeath;

    Animator animator;


    void Start()
    {
        lives = 1;
        animator = GetComponentInChildren<Animator>();
    }

    private void FixedUpdate()
    {
        isGrounded();

        if (isGrounded() == false)
        {
            bool Falling = animator.GetBool("Grounded");
            animator.SetBool("Grounded", false);

            transform.position += Vector3.down * .098f;

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
            return true;
        }
        else
        {
            return false;
        }

    }

    public void CheckDeath(int livesChange)
    {
        lives += livesChange;

        if (lives < 0) Death();
    }

    void Death()
    {

        is_death = true;
        Rigidbody rgb = GetComponent<Rigidbody>();
        rgb.constraints = RigidbodyConstraints.FreezeAll;

        bool Dead = animator.GetBool("Dead");
        animator.SetBool("Dead", true);

        
        PlayerMovementHybrid pMH = GetComponent<PlayerMovementHybrid>();
        pMH.dead = true;

        Canvasdeath.gameObject.SetActive(true);
    }
    /*
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Dead")
        {
            Debug.Log("muerase");
            Death();
        }
    }*/

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Dead")
        {
            Debug.Log("-1 vida");
            CheckDeath(-1);
        }
        if (other.tag == "FallDead")
        {
            Death();
        }

    }
}
