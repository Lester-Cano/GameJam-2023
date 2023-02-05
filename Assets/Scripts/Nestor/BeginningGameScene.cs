using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BeginningGameScene : MonoBehaviour
{
    [SerializeField] Canvas fade, clock;

    [SerializeField] GameObject canvasfirst1, canvasfirst2, canvasfirst3;

    [SerializeField] Material Skybox1, Skybox2, Skybox3;

    public bool TransitionBool;

    public float timer = 0f;

    public AudioSource audioswitch;

   /* public void playLightSFX()
    {
        audioswitch.Play();
    }
    */


    private void Update()
    {

        if (timer < 50)
        {
            timer += Time.deltaTime;
        }


        if (timer > 23 && timer < 23.5)
        {
            phase1C();
        }
        else if (timer > 24 && timer < 47)
        {
            phase2();
        }
        else if (timer > 47 && timer < 47.5)
        {
            phase3C();
        }
        else if (timer > 48 && timer < 48.5)
        {
            fade.gameObject.SetActive(false);
            TransitionBool= false;
        }
    }

    void phase1C()
    {
        fade.gameObject.SetActive(true);
        canvasfirst1.gameObject.SetActive(false);
        RenderSettings.skybox = Skybox2;
        TransitionBool = true;
    }
    void phase2()
    {
        canvasfirst2.gameObject.SetActive(true);
        fade.gameObject.SetActive(false);
        TransitionBool= false;
    }

    void phase3C()
    {
        fade.gameObject.SetActive(true);
        TransitionBool= true;
        canvasfirst3.gameObject.SetActive(true);
        canvasfirst2.gameObject.SetActive(false);
        RenderSettings.skybox = Skybox3;
    }
}
