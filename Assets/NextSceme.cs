using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextSceme : MonoBehaviour
{
    public bool Next_level = (false);
    public int Level_index = 0;
    // Update is called once per frame

    public void LoadNextLevel()
    {
        Next_level = true;
    }
    
    void Update()
    {

        if (Next_level)
        {
           SceneManager.LoadScene(Level_index + 1 );
        }

    }
}
