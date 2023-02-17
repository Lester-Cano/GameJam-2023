using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerToAppear : MonoBehaviour
{
    public float TimetoApear;
    public float DuracionDeVideo;
    public GameObject button;



    // Start is called before the first frame update
    void Start()
    {
        TimetoApear = 0.0f;

    }

    // Update is called once per frame
    void Update()
    {
        TimetoApear += Time.deltaTime;

        if (TimetoApear > DuracionDeVideo)
        {
            button.SetActive(true);
        }
    }
}
