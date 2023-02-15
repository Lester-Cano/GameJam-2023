using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class VolumeSlider : MonoBehaviour
{
    [SerializeField] Slider volumeSliderMusic,volumeSliderSFX;
    public AudioMixerGroup SFX, Music;
    
    // Start is called before the first frame update
   /* void Start()
    {
        if (!PlayerPrefs.HasKey("musicVolume")) 
        {
            PlayerPrefs.SetFloat("musicVolume",1);
            //Load();
        } 
        else
        {
            //Load();
        }
    }
   */
   
    public void ChangeAudioMixer()
    {
        SFX.audioMixer.SetFloat("SFXVolume", volumeSliderSFX.value);
        Music.audioMixer.SetFloat("MusicVolume", volumeSliderMusic.value);

       // Save();
    }
/*
    private void Load()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("musicVolume");
    }

    private void Save()
    {
        PlayerPrefs.SetFloat("musicVolume", volumeSlider.value);
    }
        
    // Update is called once per frame
    void Update()
    {
        
    }
*/
}
