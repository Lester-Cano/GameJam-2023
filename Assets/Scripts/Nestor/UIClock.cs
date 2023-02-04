using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class UIClock : MonoBehaviour
{
    float timeDuration = 0f;

    float timer;

    [SerializeField] TextMeshProUGUI clock;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        UpdateTimerDisplay(timer);
        if (timer > 23)
        {
            MapEvent();
            timer= 0;
        }
    }

    void ResetTimer()
    {
        timer = timeDuration;
    }

    void UpdateTimerDisplay(float time)
    {
        float minutes = Mathf.Floor(time / 60);
        float seconds = Mathf.Floor(time % 60);

        string currentTime = seconds.ToString();
        clock.text = currentTime.ToString();
    }

    void MapEvent()
    {

    }
}
