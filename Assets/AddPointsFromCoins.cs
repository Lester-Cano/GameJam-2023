using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddPointsFromCoins : MonoBehaviour
{

    [SerializeField] ControladorPuntos cp;

    public ParticleSystem parti;

    void Start()
    {
        cp = FindObjectOfType<ControladorPuntos>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            cp.cantidadPuntos += 50;
            cp.UpdatePointsDisplay();
            gameObject.SetActive(false);
            parti.Emit(0);
        }
    }
}
