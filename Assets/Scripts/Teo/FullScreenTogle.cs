using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullScreenTogle : MonoBehaviour
{
    public void FullScreen(bool is_fullscene)
    {
        Screen.fullScreen = is_fullscene;
        Debug.Log("Full screen is " + is_fullscene);

    }
   
}
