using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class audioSlider : MonoBehaviour
{
    public Slider mySlider;
    public AudioSource source;
    public string saveName;

    public void Awake()
    {
        if (mySlider.value!=PlayerPrefs.GetFloat(saveName)&& PlayerPrefs.GetFloat(saveName)!=0)
            mySlider.value = PlayerPrefs.GetFloat(saveName);

        if (PlayerPrefs.GetFloat(saveName) == 0)    //will only ever be 0 on the first time opening the build
            mySlider.value = 0.8f;  //because the min value for the slider is 0.001

        if (source!=null)
        source.volume = mySlider.value;
    }

    public void onChangeValue ()
    {
        if (source != null)
        source.volume = mySlider.value;
    }

    public void updateFromPref()
    {
        if (mySlider.value != PlayerPrefs.GetFloat(saveName))
            mySlider.value = PlayerPrefs.GetFloat(saveName);
    }

    public void saveMyValue()
    {
        PlayerPrefs.SetFloat(saveName, mySlider.value);
        PlayerPrefs.Save();
    }
}
