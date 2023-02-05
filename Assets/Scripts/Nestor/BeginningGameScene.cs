using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BeginningGameScene : MonoBehaviour
{
    [SerializeField] Canvas fade;

    [SerializeField] GameObject canvasfirst1, canvasfirst2, canvasfirst3;

    [SerializeField] Material Skybox1, Skybox2, Skybox3;

    float timer = 0f;

    //AudioSource audioswitch;

    private void Start()
    {
        
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer % 60 > 5 && timer % 60 < 7)
        {
            phase1();
        }
        else if (timer % 60 > 7 && timer % 60 < 10)
        {
            phase2();
        }
        else if (timer % 60 > 10 && timer % 60 < 11)
        {
            phase3();
        }
        else if (timer % 60 > 11 && timer % 60 < 12)
        {
            fade.gameObject.SetActive(false);
           // audioswitch.Play();
        }
    }

    void phase1()
    {
        fade.gameObject.SetActive(true);
        //audioswitch.Play();
        canvasfirst1.gameObject.SetActive(false);
        RenderSettings.skybox = Skybox2;
    }
    void phase2()
    {
        canvasfirst2.gameObject.SetActive(true);
        //audioswitch.Play();
        fade.gameObject.SetActive(false);
    }

    void phase3()
    {
        //audioswitch.Play();
        fade.gameObject.SetActive(true);
        canvasfirst3.gameObject.SetActive(true);
        canvasfirst2.gameObject.SetActive(false);
        RenderSettings.skybox = Skybox3;
    }
}
