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

    public bool activarlvl1 = false;
    public bool activarlvl2 = false;
    public bool activarlvl3 = false;

    public GameObject PrefabMapa;


    public float TimeAnimEspera;

    public float tiempoSpamLvl;

    public float cantidadPantalla;


    List<int> rnds = new List<int>();

    List<int> EventRnds = new List<int>();



    [Header("Eventos")]
    public bool esEvento = false;
  

    // Start is called before the first frame update
    void Start()
    {
        ObjetosCompletos = new List<PrefabMap>();
        rnds = new List<int>();
        EventRnds = new List<int>();
      
            StartCoroutine(ActivarEvento());
        
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
        if (esEvento)
        {
            StopCoroutine(ActivateRandomCubes());
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
        //cantidadPantalla += 2;
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
        while (!esEvento)
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

    public float tiempoPostEvento;
    public float tiempoDañoEvento;
    private IEnumerator ActivarEvento() 
    {
        yield return new WaitForSeconds(2);
           
        int radn = Random.Range(0, 5);
        
        if (radn == 0)
        {
           
                for (int i = 0; i < ObjetosCompletos.Count; i++)
                {
                    if (i % 2 == 0)
                    {
                        EventRnds.Add(i);
                    }
                }
                for (int i = 0; i < EventRnds.Count; i++)
                {

                    ObjetosCompletos[EventRnds[i]].Evento();
                yield return new WaitForSeconds(tiempoDañoEvento);
            }
                rnds.Clear();
            yield return new WaitForSeconds(tiempoPostEvento);
            esEvento = false;
            }
        if (radn == 1)
        {
            for (int i = 0; i < ObjetosCompletos.Count; i++)
            {
                if (i % 2 != 0)
                {
                    EventRnds.Add(i);
                }
            }
            for (int i = 0; i < EventRnds.Count; i++)
            {

                ObjetosCompletos[EventRnds[i]].Evento();
                yield return new WaitForSeconds(tiempoDañoEvento);
            }
            rnds.Clear();
            yield return new WaitForSeconds(2);
            esEvento = false;
        }
        if (radn == 2)
        {
            for (int i = 0; i < ObjetosCompletos.Count; i++)
            {
                EventRnds.Add(i);
            }
            int numerf = EventRnds.Count / 2 ;

            for (int i = EventRnds.Count -1; i > numerf; i--)
            {
                ObjetosCompletos[EventRnds[i]].Evento();
                yield return new WaitForSeconds(tiempoDañoEvento);
            }
            rnds.Clear();
            yield return new WaitForSeconds(tiempoPostEvento);
            esEvento = false;
        }
        if (radn == 3)
        {
            for (int i = 0; i < ObjetosCompletos.Count; i++)
            {
                
                EventRnds.Add(i);
            }
            int numerf = EventRnds.Count / 2 ;
            for (int i = 0; i < numerf; i++)
            {
                ObjetosCompletos[EventRnds[i]].Evento();
                yield return new WaitForSeconds(tiempoDañoEvento);

            }        
            rnds.Clear();
            yield return new WaitForSeconds(tiempoPostEvento);
            esEvento = false;
        }
        if (radn == 4)
        {
            for (int i = 0; i < 70; i++)
            {

                EventRnds.Add(i);
            }
            for (int i = 0; i < EventRnds.Count; i++)
            {
                ObjetosCompletos[EventRnds[i]].Evento();
                yield return new WaitForSeconds(tiempoDañoEvento);

            }
            rnds.Clear();
            yield return new WaitForSeconds(tiempoPostEvento);
            esEvento = false;
        }
        if (radn == 5)
        {
            for (int i = 0; i < 70; i++)
            {

                EventRnds.Add(i);
            }
            for (int i = 69 ; i > 0; i--)
            {
                ObjetosCompletos[EventRnds[i]].Evento();
                yield return new WaitForSeconds(tiempoDañoEvento);

            }
            rnds.Clear();
            yield return new WaitForSeconds(tiempoPostEvento);
            esEvento = false;
        }
        print(radn);
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

    public void Encender()
    {
        //Debug.Log($"Encender >> {gameObject.name}");
        StartCoroutine(IniciarJuego());
    }
    public void ActivarPatrones()
    {       
        StartCoroutine(ActivarEvento());
    }

    public void ActivarRandom()
    {
        StartCoroutine(ActivateRandomCubes());
    }
    IEnumerator IniciarJuego() 
    {    
        yield return new WaitForSeconds(2);
        activarlvl1 = true;
    
    }

}

