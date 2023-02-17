using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubstractTime : MonoBehaviour
{

    [SerializeField] float timeToSubstract;

    UIClock clock;
    // Start is called before the first frame update
    void Start()
    {
        clock = FindObjectOfType<UIClock>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            clock.timer23 -= timeToSubstract;
        }
    }

}
