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

    public List<PrefabMap> ObjetosCompletos;

    public bool evento = false;


    public bool activarlvl1 = false;
    public bool activarlvl2 = false;
    public bool activarlvl3 = false;

    public GameObject PrefabMapa;


    public float TimeAnimEspera;

    public float tiempoSpamLvl;

    public float cantidadPantalla;


    List<int> rnds = new List<int>();



    // Start is called before the first frame update
    void Start()
    {
        ObjetosCompletos = new List<PrefabMap>();
        rnds = new List<int>();
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

            GameObject instance = Instantiate(PrefabMapa, PuntoInstlvl1[i].transform.position, PuntoInstlvl1[i].transform.rotation);
            var prefabMap = instance.GetComponent<PrefabMap>();
            ObjetosCompletos.Add(prefabMap);
            yield return new WaitForSeconds(TimeAnimEspera);
        }

        StartCoroutine(ActivateRandomCubes());
    }
    IEnumerator generarlvl2()
    {
        yield return new WaitForSeconds(TimeAnimEspera);
        for (int i = 0; i < PuntoInstlvl2.Length; i++)
        {

            GameObject instance = Instantiate(PrefabMapa, PuntoInstlvl2[i].transform.position, PuntoInstlvl2[i].transform.rotation);
            var prefabMap = instance.GetComponent<PrefabMap>();
            ObjetosCompletos.Add(prefabMap);
         
            yield return new WaitForSeconds(TimeAnimEspera);
        }
        cantidadPantalla += 2;
    }
    IEnumerator generarlvl3()
    {
        yield return new WaitForSeconds(TimeAnimEspera);
        for (int i = 0; i < PuntoInstlvl3.Length; i++)
        {

            GameObject instance = Instantiate(PrefabMapa, PuntoInstlvl3[i].transform.position, PuntoInstlvl3[i].transform.rotation);
            var prefabMap = instance.GetComponent<PrefabMap>();
            ObjetosCompletos.Add(prefabMap);
            yield return new WaitForSeconds(TimeAnimEspera);
        }
        cantidadPantalla += 3;
    }

    

    private IEnumerator ActivateRandomCubes()
    {
        while (true)
        {
            // Genera randoms
            for (int i = 0; i < cantidadPantalla; i++)
            {
                int random = Random.Range(0, ObjetosCompletos.Count);                
                while (rnds.Contains(random))
                {
                    random = Random.Range(0, ObjetosCompletos.Count);
                }
                rnds.Add(random);         
            }

            for (int i = 0; i < rnds.Count; i++)
            {
                ObjetosCompletos[rnds[i]].Encender();               
            }

            rnds.Clear();
            yield return new WaitForSeconds(tiempoSpamLvl);
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

    public void Encender()
    {
        //Debug.Log($"Encender >> {gameObject.name}");
        StartCoroutine(IniciarJuego());
    }

    IEnumerator IniciarJuego() 
    {

        yield return new WaitForSeconds(1);
        activarlvl1 = true;
    
    }
}

