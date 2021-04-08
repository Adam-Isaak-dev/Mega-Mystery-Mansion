using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [Header("Standard Sound Effects")]
    public AudioClip pickup;
    public AudioClip tik;
    public AudioClip horror;
    public AudioClip metalWalk;
    public AudioClip evilLaugh;
    public AudioClip glassBreak;
    public AudioClip machineStruggle;
    public AudioClip doorLocked;
    public AudioClip doorOpen;
    public AudioClip confirm;
    public AudioClip mouseVoice;
    public AudioClip armourVoice;
    public AudioClip ghostVoice;
    public AudioClip shelfMove;
    public AudioClip woosh;
    public AudioClip card;
    public AudioClip voiceLaugh;
    public AudioClip voiceMetal;
    public AudioClip voiceTik;

    [Header("Source")]
    public AudioSource audioSource;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(instance);
        }

        if (PlayerPrefs.GetFloat("soundVol") > 0)
            audioSource.volume = PlayerPrefs.GetFloat("soundVol");
        else
            audioSource.volume = 0.8f;
        if (audioSource.volume < 0.0001f)
            audioSource.volume = 0.8f;
    }

    public void PlayClip(AudioClip clip)
    {
        if (clip == doorLocked || clip == doorOpen || clip == tik|| clip==voiceTik||clip== glassBreak||clip==mouseVoice||clip==armourVoice||clip==ghostVoice)  //<-- include sound effects that are randomized here
            audioSource.pitch = Random.Range(0.90f, 1.10f);
        else
            if(clip==voiceMetal)
            audioSource.pitch = 0.8f;
        else
            if(clip == voiceLaugh)
            audioSource.pitch = Random.Range(0.75f, 0.85f);
        else
            audioSource.pitch = 1f;
        audioSource.PlayOneShot(clip);
    }


}
