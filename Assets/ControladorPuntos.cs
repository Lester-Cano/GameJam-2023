using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorPuntos : MonoBehaviour
{
    public static ControladorPuntos Instance;
    [SerializeField] public float cantidadPuntos;

    UIClock uiclock;

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
        uiclock = GetComponent<UIClock>();
        PlayerPrefs.SetFloat("Temporal Points", 0);
    }

    private void Update()
    {
        cantidadPuntos = uiclock.TimeScore;
    }

    public void FinalPartida()
    {
        

        PlayerPrefs.SetFloat("Temporal Points", uiclock.timeCooldownEvent);

        Highest hg = GameObject.FindObjectOfType<Highest>();
        hg.ReviewData();

    }


}


