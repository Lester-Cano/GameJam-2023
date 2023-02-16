using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ControladorPuntos : MonoBehaviour
{
    public static ControladorPuntos Instance;
    [SerializeField] public float cantidadPuntos = 0;

    [SerializeField] TextMeshProUGUI scoreUI;

    [SerializeField] Highest hg;

    

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
        GameEvents.current.onScoreMinute += AddScore;
        GameEvents.current.onPlayerDeath += SaveScore;
    }

    public void AddScore()
    {
        cantidadPuntos += 100;
        scoreUI.text = cantidadPuntos.ToString();
    }

    public void SaveScore()
    {
        PlayerPrefs.SetFloat("Temporary Points", cantidadPuntos);
    }

     
        

}


