using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorPuntos : MonoBehaviour
{
    public static ControladorPuntos Instance;
    [SerializeField] public int cantidadPuntos;

    private void Awake()
    {
        if (ControladorPuntos.Instance == null)
        {
            ControladorPuntos.Instance = this;
            DontDestroyOnLoad(this.gameObject);

        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void SumarPuntos(int puntos)
    {
        cantidadPuntos += puntos;
    }

    public void FinalPartida()
    {
        PlayerPrefs.SetInt ("Temporal Points",cantidadPuntos);
        //Lllamr funcion
        Highest hg = GameObject.FindObjectOfType<Highest>();
        hg.ReviewData();

    }


}


