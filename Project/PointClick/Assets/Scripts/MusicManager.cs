using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MusicManager : MonoBehaviour
{
    public static MusicManager instance;

    public AudioSource source;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;  
        }
        else
        {
            Destroy(instance);
        }

        //set volume
        if(PlayerPrefs.GetFloat("musicVol")>0)
            source.volume = PlayerPrefs.GetFloat("musicVol");
        else
            source.volume = 0.8f;
        Debug.Log("started scene with music volume "+PlayerPrefs.GetFloat("musicVol"));
    }

    public void changeBGM(AudioClip music)
    {
        if (music != source.clip)
        {
            source.Stop();
            source.clip = music;
            source.Play();
        }
    }
}
