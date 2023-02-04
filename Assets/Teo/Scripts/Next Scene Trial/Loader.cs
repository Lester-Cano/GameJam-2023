using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loader : MonoBehaviour
{

    public Animator transition;
    public float transitionTime = 0;
    public string sceneName;
    public bool StartTimer = false;
    public float medida = 2;
    // Update is called once per frame
    void Update()
    {
        if (StartTimer)
        {
            transitionTime += Time.deltaTime;
        }
        if (transitionTime > medida)
        {
            SceneManager.LoadScene(sceneName);
        }
    }
    public void LoadNextLevel()
    {
        StartTimer = true;
    
    }

}
