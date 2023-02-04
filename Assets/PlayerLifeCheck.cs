using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLifeCheck : MonoBehaviour
{
    public bool grounded = false;
    public float groundedCheckDistance;
    float bufferCheckDistance;


    void Start()
    {
        
    }

    private void FixedUpdate()
    {

        isGrounded();

        if (isGrounded() == false)
        {
            Debug.Log("grounded");
            Death();
        }
        
    }

    bool isGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, 0.5f);
    }

    void Death()
    {

    }
}
