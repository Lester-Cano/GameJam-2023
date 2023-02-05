using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabMap : MonoBehaviour
{
    public Material MatBase;

    public Mov1_1 main;


    [Header("Apartado de Daño")]

    public GameObject MaloPrefOn;
    public GameObject MalooPrefOff;

    [Header("Bueno")]

    public GameObject BuenoPrefOn;
    public GameObject BuenoPrefOff;

    [Header("Daños")]

    public GameObject Puas;
    public float TiempoEspamPuas;


    public float TimeAnimEspera;


    public float tiempoSpamLvl1;
    public float tiempoSpamLvl2;
    public float tiempoSpamLvl3;




    // Start is called before the first frame update
    private void Awake()
    {
        
        main = FindObjectOfType<Mov1_1>();

    }
    void Start()
    {

        MaloPrefOn.SetActive(false);
        MalooPrefOff.SetActive(false);

        BuenoPrefOn.SetActive(false);
        BuenoPrefOff.SetActive(false);

        Puas.SetActive(false);   
              
    }
    private void Update()
    {
        
    }
    // Update is called once per frame
    IEnumerator RandomLvl1()
    {
        yield return new WaitForSeconds(tiempoSpamLvl1);
        
       
            Puas.SetActive(true);

       
        yield return new WaitForSeconds(tiempoSpamLvl1);
        if (main.evento == false)
        {
            Puas.SetActive(false);
            StartCoroutine(RandomLvl1());
        }
        else if (main.evento == true )
        {

        }

    }

    public void Encender() 
    {
        StartCoroutine(RandomLvl1());
    }
}
