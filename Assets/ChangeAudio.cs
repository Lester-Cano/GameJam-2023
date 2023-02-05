using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeAudio : MonoBehaviour
{
    [SerializeField] AudioSource music;
    [SerializeField] AudioClip audio;
    PlayerMovementHybrid phm;
    private void Start()
    {
        phm = GameObject.FindObjectOfType<PlayerMovementHybrid>().GetComponent<PlayerMovementHybrid>();
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
