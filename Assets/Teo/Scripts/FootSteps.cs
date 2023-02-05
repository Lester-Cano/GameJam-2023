using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootSteps : MonoBehaviour
{
    public AudioSource StepSFX;
    private AudioClip clip;
   



    private void Awake()
    {
        StepSFX = GetComponent<AudioSource>();
    }

    /*public void PlayStepSFX()
    {
        StepSFX.PlayOneShot;
    }*/
    private void Step()
    {
        StepSFX.PlayOneShot(clip);
    }


}
