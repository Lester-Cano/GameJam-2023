using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class UIClock : MonoBehaviour
{
    public float timeCooldownEvent = 23f;

    public float timer23 = 23, TimeScore;

    [SerializeField] TextMeshProUGUI clock23, clockFM, clockSM, clockFS, clockSS;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TimeScore += Time.deltaTime;
        timer23 -= Time.deltaTime;
        UpdateTimerDisplay23(timer23);
        UpdateTimerDisplay(TimeScore);
        if (timer23 == 0)
        {
            //MapEvent();
            ResetTimer();
        }
    }

    void ResetTimer()
    {
        timer23 = timeCooldownEvent;
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
