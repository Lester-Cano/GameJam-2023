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

    bool protaAlive = true;


    void Start()
    {
        protaAlive = true;
        timer23 = 0;
        timeScore = 0;
        GameEvents.current.onPlayerDeath += GameOver;
    }

    // Update is called once per frame
    void Update()
    {

        if (protaAlive)
        {
            timeScore += Time.deltaTime;
            timer23 += Time.deltaTime;
            UpdateTimerDisplay23(timer23);
            UpdateTimerDisplay(timeScore);
        }
    }

    

    void UpdateTimerDisplay23(float time)
    {
        float minutes = Mathf.Floor(time / 60);
        float seconds = Mathf.Floor(time % 60);

        string currentTime = seconds.ToString();
        clock23.text = currentTime.ToString();

        if (seconds >= 23)
        {
            GameEvents.current.ChangeStage();
            seconds -= 23;
            timer23 = 0;
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
            GameEvents.current.ScoreMinute();
            minutes -= 1;
            seconds = 0;
            timeScore = 0;
        }

    }

    public void GameOver()
    {
        protaAlive= false;
        timeScore = 0;
        timer23 = 0;
        UpdateTimerDisplay23(timer23);
        UpdateTimerDisplay(timeScore);
    }
    
}
