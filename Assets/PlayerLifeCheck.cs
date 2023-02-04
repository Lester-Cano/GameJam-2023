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
            Debug.Log(" not grounded");
            Death();
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

    void Death()
    {

    }
}
