using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeAudio : MonoBehaviour
{
    [SerializeField] AudioSource music;
    [SerializeField] AudioClip audio;
    PlayerMovementHybrid phm;
    private void Start()
    {
        if (SceneManager.sceneCount != 0)
        {
            phm = GameObject.FindObjectOfType<PlayerMovementHybrid>().GetComponent<PlayerMovementHybrid>();
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F)) ;
        //music.Play();
        music.clip = audio;
        music.Play();
        //changeAudio(audio);
    }
   /* public void changeAudio(AudioClip audio)
    {
        if (phm.isDashing)
        {
            music.Play();
            music.clip = audio;
            music.Play();
        }
        
    }
    */
}
