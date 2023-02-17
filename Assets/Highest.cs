using UnityEngine;
using TMPro;


public class Highest : MonoBehaviour
{
    public string paso;


    // Start is called before the first frame update
    void Start()
    {
        GameEvents.current.onPlayerDeath += ReviewData;
    }

    public void ReviewData()
    {
        float DataToReview = PlayerPrefs.GetFloat("Temporary Points");
        float tmp1, tmp2, tmp3;

        if (DataToReview > PlayerPrefs.GetFloat("HighScore"))
        {
            tmp1 = PlayerPrefs.GetFloat("HighScore");
            PlayerPrefs.SetFloat("HighScore", DataToReview);
        }
        else
        {
            tmp1 = DataToReview;
        }

        if (tmp1 > PlayerPrefs.GetFloat("SecondHighest"))
        {
            tmp2 = PlayerPrefs.GetFloat("SecondHighest");
            PlayerPrefs.SetFloat("SecondHighest", tmp1);
        }
        else
        {
            tmp2 = tmp1;
        }
        if (tmp2 > PlayerPrefs.GetFloat("ThirdHighest"))
        {
            tmp3 = PlayerPrefs.GetFloat("ThirdHighest");
            PlayerPrefs.SetFloat("ThirdHighest",tmp2);
        }
        else
        {
            tmp3 = tmp2;
        }
    }
}
