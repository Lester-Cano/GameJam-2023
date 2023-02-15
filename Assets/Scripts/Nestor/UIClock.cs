using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class UIClock : MonoBehaviour
{
    public float timeCooldownEvent = 23f;

    public float timer23, timeScore;

    [SerializeField] TextMeshProUGUI clock23, clockFM, clockSM, clockFS, clockSS;


    void Start()
    {
        timer23 = 0;
        timeScore = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timeScore += Time.deltaTime;
        timer23 += Time.deltaTime;
        UpdateTimerDisplay23(timer23);
        UpdateTimerDisplay(timeScore);
        
    }

    

    void UpdateTimerDisplay23(float time)
    {
        float minutes = Mathf.Floor(time / 60);
        float seconds = Mathf.Floor(time % 60);

        string currentTime = seconds.ToString();
        clock23.text = currentTime.ToString();

        if (seconds >= 23)
        {
            //EVENTO DEL 23
        }

    }
    void UpdateTimerDisplay(float time)
    {
        float minutes = Mathf.Floor(time / 60);
        float seconds = Mathf.Floor(time % 60);

        string currentTime = string.Format("{00:00}{1:00}", minutes, seconds);
        clockFM.text = currentTime[0].ToString();
        clockSM.text = currentTime[1].ToString();
        clockFS.text = currentTime[2].ToString();
        clockSS.text = currentTime[3].ToString();

        if (minutes >= 1)
        {
            //EVENTO DE PUNTAJE
        }

    }

    void MapEvent()
    {

    }
}
