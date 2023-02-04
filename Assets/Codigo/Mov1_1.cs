using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mov1_1 : MonoBehaviour
{
    public int TamañoPlataforma = 3;
    
    public Vector3 limiteCrea;
 
    
    
    public GameObject PrefabMapa;
  

    // Start is called before the first frame update
    void Start()
    {
  
        

    }

    // Update is called once per frame
    void Update()
    {
        if (limiteCrea.x != TamañoPlataforma && limiteCrea.y != TamañoPlataforma)
        {
            for (int i = 0; i < TamañoPlataforma; i++)
            {
                limiteCrea = new Vector3(i, 0, 0);
                if (i >= TamañoPlataforma)
                {
                    for (int a = 0; a < TamañoPlataforma; a++)
                    {
                        limiteCrea = new Vector3(0, 0, a);
                        Instantiate<GameObject>(PrefabMapa, limiteCrea, PrefabMapa.transform.rotation);
                    }
                }
                else
                {
                    Instantiate<GameObject>(PrefabMapa, limiteCrea, PrefabMapa.transform.rotation);
                }


            }
        }

        if (Input.GetKeyDown("r"))
        {

        }
    }
}
