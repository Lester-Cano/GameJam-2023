using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXPlaying : MonoBehaviour
{
    public AudioSource DashSFX;
    public AudioSource DieSFX;
    PlayerMovementHybrid PlayerReffDash;
    PlayerLifeCheck PlayerReffDie;
    public bool deathCheck;


    private void Start()
    {
        PlayerReffDash = FindObjectOfType<PlayerMovementHybrid>().GetComponent<PlayerMovementHybrid>();
        PlayerReffDie = FindObjectOfType<PlayerLifeCheck>().GetComponent<PlayerLifeCheck>();
        deathCheck = true;
    }
    public void PlayDashSFX()
    {
        DashSFX.Play();
    }
    public void PlayDieSFX()
    {
        deathCheck = false;
        DieSFX.Play();
    }

    private void Update()
    {
     /*   if (Input.GetKeyDown(KeyCode.F) && PlayerReffDash.isDashing)
        {
            PlayDashSFX();
        }

        if (PlayerReffDie.is_death && deathCheck)
        {
            PlayDieSFX();

        }
     */
        
    }

}
