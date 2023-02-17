using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorPuntos : MonoBehaviour
{
    public static ControladorPuntos Instance;
    [SerializeField] public float cantidadPuntos;

    UIClock uiclock;

    [SerializeField]
    Highest hg;

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

    private void Start()
    {
        hg = GameObject.FindObjectOfType<Highest>();
        uiclock = GetComponent<UIClock>();
    }

    private void Update()
    {
        cantidadPuntos = uiclock.TimeScore;
    }

    public void FinalPartida()
    {
        PlayerPrefs.SetFloat("Temporal Points", uiclock.timeCooldownEvent);
        //hg.ReviewData();
    }   
        

}


