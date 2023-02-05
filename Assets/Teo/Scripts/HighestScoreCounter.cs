using UnityEngine;
using TMPro;


public class HighestScoreCounter : MonoBehaviour
{
    public TextMeshProUGUI score, highScore;
    public string paso;


    // Start is called before the first frame update
    void Start()
    {

        paso  = PlayerPrefs.GetInt("HighScore", 0).ToString();
        highScore.text = paso;
    }

    public void ReviewData()
    {
        int DataToReview = PlayerPrefs.GetInt("Temporary Points");
        int tmp1, tmp2, tmp3;

        if (DataToReview > PlayerPrefs.GetInt("HighScore"))
        {
            tmp1 = PlayerPrefs.GetInt("HighScore");
            PlayerPrefs.SetInt("HighScore", DataToReview);
        }
        else
        {
            tmp1 = DataToReview;
        }

        if (tmp1 > PlayerPrefs.GetInt("SecondHighest"))
        {
            tmp2 = PlayerPrefs.GetInt("SecondHighest");
            PlayerPrefs.SetInt("SecondHighest", tmp1);
        }
        else
        {
            tmp2 = tmp1;
        }
        if (tmp2 > PlayerPrefs.GetInt("ThirdHighest"))
        {
            tmp3 = PlayerPrefs.GetInt("ThirdHighest");
            PlayerPrefs.SetInt("ThirdHighest",tmp2);
        }
        else
        {
            tmp3 = tmp2;
        }
    }
}
