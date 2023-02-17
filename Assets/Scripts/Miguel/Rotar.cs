using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotar : MonoBehaviour
{
    public float rotationSpeed = 10f;

    // Update is called once per frame
    void Update()
    {
        Vector3 localUp = transform.InverseTransformDirection(Vector3.up);
        transform.Rotate(localUp, rotationSpeed * Time.deltaTime);
    }
}

