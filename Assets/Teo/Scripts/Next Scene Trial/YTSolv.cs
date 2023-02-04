using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class YTSolv : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;
    public int levelIndex = 0;

    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel());
        
    }

    IEnumerator LoadLevel ()
    {
        yield return new WaitForSeconds(transitionTime);

        transition.SetTrigger("Start");


        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(levelIndex+1);



    }
}
