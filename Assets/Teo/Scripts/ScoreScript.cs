using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreScript : MonoBehaviour
{
   /* public TextMeshProUGUI MyscoreText;
    [SerializeField]public int ScoreNum;*/

    [SerializeField] TextMeshProUGUI HighestScore, SecondHighest, ThirdHiguest;

    [SerializeField] private int cantidadPuntos = 1;
    
    // Start is called before the first frame update
    void Start()
    {
     //   ScoreNum = 0;
     // MyscoreText.text = "Score: " + ScoreNum;
    }

    // Update is called once per frame
    void Update()
    {
       /* if (Input.GetKeyDown(KeyCode.Space))
        {
            ControladorPuntos.Instance.SumarPuntos(cantidadPuntos);
            ScoreNum ++ ;
            MyscoreText.text = "Score " + ScoreNum;
        }*/
    }

    public void AsignScore()
    {

        float minutesFirst = Mathf.Floor(PlayerPrefs.GetFloat("HighScore") / 60);
        float secondsFirst = Mathf.Floor(PlayerPrefs.GetFloat("HighScore") % 60);

        string currentTime = string.Format("{00:00}:{1:00}", minutesFirst, secondsFirst);

        float minutesSecond = Mathf.Floor(PlayerPrefs.GetFloat("HighScore") / 60);
        float secondsSecond = Mathf.Floor(PlayerPrefs.GetFloat("HighScore") % 60);

        string currentTime2 = string.Format("{00:00}:{1:00}", minutesSecond, secondsSecond);

        float minutesThird = Mathf.Floor(PlayerPrefs.GetFloat("HighScore") / 60);
        float secondsThird = Mathf.Floor(PlayerPrefs.GetFloat("HighScore") % 60);

        string currentTime3 = string.Format("{00:00}:{1:00}", minutesThird, secondsThird);

        HighestScore.text = currentTime.ToString();
        SecondHighest.text = currentTime2.ToString();
        ThirdHiguest.text = currentTime3.ToString();

    }

}
