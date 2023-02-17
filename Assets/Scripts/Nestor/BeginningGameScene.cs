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

    public Mov1_1 main;

    public bool phasetwoMusicON;


    //Stage Number
    [SerializeField] int stage = 1;


    private void Awake()
    {
        main = FindObjectOfType<Mov1_1>();
    }


    private void Start()
    {
        GameEvents.current.onChangeStage += CheckStage;
    }


    public void CheckStage()
    {
        if (stage == 1) 
        {
            Debug.Log("Stage 1");
            StartCoroutine(phase1()); 
        }
        else if (stage == 2) 
        {
            StartCoroutine(phase2());
        }
        else if (stage == 3) 
        {
            GameEvents.current.StageEvent();
            /*EVENTO DE CORUTINAAAAAA*/ 
        }
    }

    IEnumerator phase1()
    {

        Debug.Log("Entro a corutina");

        fade.gameObject.SetActive(true);
        canvasfirst1.gameObject.SetActive(false);
        TransitionBool = true;

        yield return new WaitForSeconds(1);

        RenderSettings.skybox = Skybox2;
        canvasfirst2.gameObject.SetActive(true);
        fade.gameObject.SetActive(false);
        TransitionBool = false;
        stage = 2;
        if (!entera2)
        {
            entre2();
        }
        //playLightSFX();     

    }
    IEnumerator phase2()
    {

        fade.gameObject.SetActive(true);
        TransitionBool = true;
        canvasfirst3.gameObject.SetActive(true);
        canvasfirst2.gameObject.SetActive(false);
        RenderSettings.skybox = Skybox3;
        //playLightSFX();      
        if (!entera3)
        {
            entre3();
        }

        yield return new WaitForSeconds(1);

        fade.gameObject.SetActive(false);
        TransitionBool = false;
        stage = 3;

        //playBGMusic();     

    }

    public bool entera2 = false;
    public bool entera3 = false;


    public void entre2() 
    {
        main.activarlvl2 = true;
        main.cantidadPantalla = 30;
        entera2= true;
    }

    public void entre3()
    {
        main.activarlvl3 = true;    
        main.cantidadPantalla = 60;
        entera3= true;
        phasetwoMusicON = true;
    }
}
