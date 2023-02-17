using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour
{

    public static GameEvents current;

    private void Awake()
    {
        current = this;
    }


    public event Action onChangeStage;
    public event Action onScoreMinute;
    public event Action onPlayerDeath;
    public event Action onStageEvent;
    public void ChangeStage()
    {

        if (onChangeStage != null)
        {
            onChangeStage();
        }

    }

    public void ScoreMinute()
    {
        if (onScoreMinute != null) 
        {
        onScoreMinute();
        }
    }

    public void PlayerDeath()
    {
        if (onPlayerDeath != null)
        {
            onPlayerDeath();
        }
    }
    public void StageEvent() 
    {
        if (onStageEvent != null)
        {
            onStageEvent();
        }
    }


}
