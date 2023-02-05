using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeginningGameScene : MonoBehaviour
{

    [SerializeField] Camera maincamera;

    [SerializeField] Canvas canvasfirst1, canvasfirst2, canvasfirst3, canvasfirst4, canvasfirst5, canvasfirst6;

    float timer = 0f;

    AudioSource audioswitch;

    private void Start()
    {
        
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer % 60 > 5)
        {
            phase1();
        }
        else if (timer % 60 > 7)
        {
            phase2();
        }
        else if (timer % 60 > 10)
        {
            phase3();
        }
        else if (timer % 60 > 11 && timer % 60 < 12)
        {
            maincamera.gameObject.SetActive(true);
            audioswitch.Play();
        }
    }

    void phase1()
    {
        audioswitch.Play();
        maincamera.gameObject.SetActive(false);
        canvasfirst1.gameObject.SetActive(false);
        canvasfirst2.gameObject.SetActive(false);
        
    }
    void phase2()
    {
        canvasfirst3.gameObject.SetActive(true);
        canvasfirst4.gameObject.SetActive(true);
        audioswitch.Play();
        maincamera.gameObject.SetActive(true);
    }

    void phase3()
    {
        audioswitch.Play();
        maincamera.gameObject.SetActive(false);
        canvasfirst3.gameObject.SetActive(false);
        canvasfirst4.gameObject.SetActive(false);
        canvasfirst5.gameObject.SetActive(true);
        canvasfirst6.gameObject.SetActive(true);
    }
}
