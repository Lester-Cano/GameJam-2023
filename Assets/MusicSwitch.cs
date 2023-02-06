using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicSwitch : MonoBehaviour
{
    public GameObject Identificadormusic;
    public GameObject MainTrackCheck;

    public GameObject DistortedTrackOn;
    BeginningGameScene BringBool;
    PlayLightSwitch BringLS;
    float timer =0;

    // Start is called before the first frame update
    void Start()
    {

        Identificadormusic.SetActive(true);
        BringBool = FindObjectOfType<BeginningGameScene>().GetComponent<BeginningGameScene>();
        DistortedTrackOn.SetActive(false);
        MainTrackCheck.SetActive(false);
        BringLS = FindObjectOfType<PlayLightSwitch>().GetComponent<PlayLightSwitch>();

    }

    // Update is called once per frame
    void Update()
    {
        /*timer += Time.deltaTime;

        if(timer >= 7 && timer < 24)
        {
        Identificadormusic.SetActive(true);
        }
        else if (timer >= 24 && timer < 68)
        {
            Identificadormusic.SetActive(false);
        }
        else if (timer >= 68)
        {
            DistortedTrackOn.SetActive(true);
        }
        */

        if (BringBool.TransitionBool)
        {
            Identificadormusic.SetActive(false);
            DistortedTrackOn.SetActive(true);
        }

        


    }

}
