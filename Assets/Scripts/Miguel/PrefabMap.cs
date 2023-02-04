using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabMap : MonoBehaviour
{
    public Material MatBase;

    public int TiempoEspam;

    public GameObject Puas;

    // Start is called before the first frame update

    void Start()
    {
        
    }

    // Update is called once per frame

    IEnumerable ActPuas()
    {
        yield return new WaitForSeconds(TiempoEspam);
        Instantiate(Puas, transform.position, transform.rotation);
        yield return new WaitForSeconds(TiempoEspam);

    }

}
