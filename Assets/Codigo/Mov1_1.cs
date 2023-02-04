using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mov1_1 : MonoBehaviour
{
    public int TamañoPlataforma = 3;

    public GameObject[] PuntoInstlvl1;
    int paso;
 
    
    
    public GameObject PrefabMapa;
  

    // Start is called before the first frame update
    void Start()
    {

        StartCoroutine(generar());

    }

    // Update is called once per frame
    void Update()
    {
    
    }

    IEnumerator generar()
    {
        yield return new WaitForSeconds(0.01f);
        for (int i = 0; i < PuntoInstlvl1.Length; i++)
        {
            
            Instantiate(PrefabMapa, PuntoInstlvl1[i].transform.position, PuntoInstlvl1[i].transform.rotation);
            yield return new WaitForSeconds(0.1f);
        }       
    }
}
    