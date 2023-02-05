using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorPuntos : MonoBehaviour
{
    [SerializeField] public int cantidadPuntos;
    public static ControladorPuntos Instance;
    private void Awake()
    {
        if (Instance == null)
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


