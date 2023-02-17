using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayLightSwitch : MonoBehaviour
{//PlayerReffDash = FindObjectOfType<PlayerMovementHybrid>().GetComponent<PlayerMovementHybrid>();
    public GameObject Identificadorsfx;
    BeginningGameScene BringBool;
 
    // Start is called before the first frame update
    void Start()
    {
       Identificadorsfx.SetActive(false);   
        BringBool  = FindObjectOfType<BeginningGameScene>().GetComponent<BeginningGameScene>();
    }

    // Update is called once per frame
    void Update()
    {
        if (BringBool.TransitionBool)
        {
            Identificadorsfx.SetActive(true);
        }
        else {
            Identificadorsfx.SetActive(false);
        }
    }
}
