using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Mov1_1 : MonoBehaviour
{

    public GameObject[] PuntoInstlvl1;
    public GameObject[] PuntoInstlvl2;
    public GameObject[] PuntoInstlvl3;

    public GameObject[] Level2AlL;

    public GameObject[] Level3All;



    [Header("Listas")]

    public List<GameObject> ObjetosCompletos;

    public bool evento = false;


    public bool activarlvl1 = false;
    public bool activarlvl2 = false;
    public bool activarlvl3 = false;

    public GameObject PrefabMapa;


    public float TimeAnimEspera;

    public int RandomMap1;
    public int RandomMap2;
    public int RandomMap3;

    public float tiempoSpamLvl1;
    public float tiempoSpamLvl2;
    public float tiempoSpamLvl3;

    public int cantidadPantalla1;
    public int cantidadPantalla2;
    public int cantidadPantalla3;



  
  

    // Start is called before the first frame update
    void Start()
    { 


    }

    // Update is called once per frame
    void Update()
    {
        if (activarlvl1)
        {
            SumarLvl1();
            activarlvl1 = false;
        }
        if (activarlvl2)
        {
            SumarLvl2();
            activarlvl2 = false;
        }
        if (activarlvl3)
        {
            SumarLvl3();
            activarlvl3 = false;
        }
    }

    IEnumerator generarlvl1()
    {
        yield return new WaitForSeconds(TimeAnimEspera);
        for (int i = 0; i < PuntoInstlvl1.Length; i++)
        {
            
            Instantiate(PrefabMapa, PuntoInstlvl1[i].transform.position, PuntoInstlvl1[i].transform.rotation);
            ObjetosCompletos.Add(PrefabMapa);
            yield return new WaitForSeconds(TimeAnimEspera);
        }
    }
    IEnumerator generarlvl2()
    {
        yield return new WaitForSeconds(TimeAnimEspera);
        for (int i = 0; i < PuntoInstlvl2.Length; i++)
        {

            Instantiate(PrefabMapa, PuntoInstlvl2[i].transform.position, PuntoInstlvl2[i].transform.rotation);
            ObjetosCompletos.Add(PrefabMapa);
            yield return new WaitForSeconds(TimeAnimEspera);
        }
    }
    IEnumerator generarlvl3()
    {
        yield return new WaitForSeconds(TimeAnimEspera);
        for (int i = 0; i < PuntoInstlvl3.Length; i++)
        {

            Instantiate(PrefabMapa, PuntoInstlvl3[i].transform.position, PuntoInstlvl3[i].transform.rotation);
            ObjetosCompletos.Add(PrefabMapa);
            yield return new WaitForSeconds(TimeAnimEspera);
        }
    }

    private void SumarLvl1()
    {

        StartCoroutine(generarlvl1());
    }
    private void SumarLvl2()
    {

        StartCoroutine(generarlvl2());
    }
    private void SumarLvl3()
    {

        StartCoroutine(generarlvl3());
    }


    public void Seleccion() 
    {
       
    }
}

