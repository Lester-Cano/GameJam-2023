using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreScript : MonoBehaviour
{
   /* public TextMeshProUGUI MyscoreText;
    [SerializeField]public int ScoreNum;*/

    [SerializeField] TextMeshProUGUI HighestScore, SecondHighest, ThirdHiguest;

    
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
        HighestScore.text = PlayerPrefs.GetFloat("HighScore").ToString();
        SecondHighest.text = PlayerPrefs.GetFloat("SecondHighest").ToString();
        ThirdHiguest.text = PlayerPrefs.GetFloat("ThirdHighest").ToString();
    }

}
