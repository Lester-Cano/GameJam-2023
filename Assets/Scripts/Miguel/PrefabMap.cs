using JetBrains.Annotations;
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


    public GameObject[] Beneficios;

    [Header("Daños")]

    public GameObject Puas;
    public GameObject Cables;
    public GameObject CablesRetorno;
    public float TiempoEspamPuas = 1;
    public float TiempoCables = 0.5f;

    
    public float TimeAnimEspera;


    public float tiempoSpamLvl;
    public float tiempoEvento;

    public bool isActive;



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
        Beneficios[0].SetActive(false);
        Beneficios[1].SetActive(false);



    }
    private void Update()
    {

    }

    // Update is called once per frame
    IEnumerator RandomLvl1()
    {
        BeneficioActivo();
        isActive = true;
        MaloPrefOn.SetActive(true);

        yield return new WaitForSeconds(tiempoSpamLvl);
        MaloPrefOn.SetActive(false);

        MalooPrefOff.SetActive(true);

        Puas.SetActive(true);

        yield return new WaitForSeconds(TiempoEspamPuas);
        MalooPrefOff.SetActive(false);
        Puas.SetActive(false);
        isActive = false;
    }

    IEnumerator preOn() 
    {
        yield return new WaitForSeconds(3);
        StartCoroutine(RandomLvl1());

    }
    public void Encender()
    {
        //Debug.Log($"Encender >> {gameObject.name}");
        StartCoroutine(preOn());
    }

    public void Evento() 
    {

        StartCoroutine(EventoCables());
    }

    IEnumerator EventoCables() 
    {
        isActive = true;
        yield return new WaitForSeconds(2);

        MaloPrefOn.SetActive(true);

        yield return new WaitForSeconds(TiempoCables);

        MaloPrefOn.SetActive(false);

        MalooPrefOff.SetActive(true);

        Cables.SetActive(true);

        yield return new WaitForSeconds(tiempoEvento);
        
        CablesRetorno.SetActive(true);

        MalooPrefOff.SetActive(false);   
        
        Cables.SetActive(false);

        yield return new WaitForSeconds(tiempoEvento/2);
        
        CablesRetorno.SetActive(false);

        isActive = true; 

    }
    public bool BuenoN = false;
    public void BeneficioActivo() 
    {
       int Rand = Random.Range(0, 50);
        print(Rand);
        if (Rand >= 48)
        {
            if (!BuenoN)
            {
                StartCoroutine(SpamBueno());
            }
            
        }
    
    }

    public IEnumerator SpamBueno()
    {   BuenoN= true;
        int cual = Random.Range(0,Beneficios.Length);
        print(cual);
        Beneficios[cual].SetActive(true);
        yield return new WaitForSeconds(5);
        Beneficios[cual].SetActive(false);
        BuenoN= false;
    }
}
