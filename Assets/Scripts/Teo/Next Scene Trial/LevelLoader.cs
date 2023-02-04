using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{

    public Animator transition;
    public float transitionTime = 1f;
    public string sceneName;
    // Update is called once per frame
    void Update()
    {
       
    }
    public void LoadNextLevel()
    {
        SceneManager.LoadScene(sceneName);

    }

}
