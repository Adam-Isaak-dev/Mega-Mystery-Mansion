using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script handles character profiles- reusable assets to make creating dialogues easy to make
//Hold information about a character- portraits for each emotion, voiceclips, name etc.

[CreateAssetMenu(fileName = "New Profile", menuName = "Character Profile")]
public class CharacterProfile : ScriptableObject
{
    public string myName;
    private Sprite myPortrait;
    public AudioClip myVoice;

    public Sprite MyPortrait
    {
        get
        {
            SetEmotionType(Emotion);
            return myPortrait;
        }
    }

    [System.Serializable]
    public class EmotionPortraits
    {
        public Sprite standard;
        public Sprite angry;
        public Sprite happy;
        public Sprite sad;

        //if a character isn't going to be sad then set their standard portrait to be the sad one etc.
    }

    public EmotionPortraits emotionPortraits;

    public EmotionType Emotion { get; set; }

    public void SetEmotionType(EmotionType newEmotion)
    {
        Emotion = newEmotion;
        switch(Emotion)
        {
            case EmotionType.Standard:
                myPortrait = emotionPortraits.standard; break;
            case EmotionType.Angry:
                myPortrait = emotionPortraits.angry; break;
            case EmotionType.Happy:
                myPortrait = emotionPortraits.happy; break;
            case EmotionType.Sad:
                myPortrait = emotionPortraits.sad; break;

        }
    }
}

//TO ADD NEW EMOTIONS, ADD TO:
//enum below
//public sprite above
//switch statement above
//REFER TO EXISTING TYPES TO ADD NEW

public enum EmotionType
{
    Standard, Angry, Happy, Sad
}