using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuScript : MonoBehaviour
{
     public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Application has quit");
    }
}
