using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class UIClock : MonoBehaviour
{
    float timeDuration = 0f;

    float timer23 = 23, normalTimer;

    [SerializeField] TextMeshProUGUI clock23, clockFM, clockSM, clockFS, clockSS;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        normalTimer += Time.deltaTime;
        timer23 -= Time.deltaTime;
        UpdateTimerDisplay23(timer23);
        UpdateTimerDisplay(normalTimer);
        if (timer23 == 0)
        {
            MapEvent();
            timer23= 0;
        }
    }

    void ResetTimer()
    {
        timer23 -= timeDuration;
    }

    void UpdateTimerDisplay23(float time)
    {
        float minutes = Mathf.Floor(time / 60);
        float seconds = Mathf.Floor(time % 60);

        string currentTime = seconds.ToString();
        clock23.text = currentTime.ToString();
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
    }

    void MapEvent()
    {

    }
}
