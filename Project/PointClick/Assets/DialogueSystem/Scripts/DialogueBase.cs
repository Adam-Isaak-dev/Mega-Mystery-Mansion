using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Dialogue", menuName = "Dialogues")]
public class DialogueBase : ScriptableObject
{
    //info for scriptable object
    [System.Serializable]
    public class Info
    {

        public CharacterProfile character;
        [TextArea(4, 8)]
        public string myText;

        public EmotionType characterEmotion;
        public void ChangeEmotion()
        {
            character.Emotion = characterEmotion;
        }
    }

    [Header("Insert Dialogue Info Below")]
    public Info[] dialogueInfo;

    //LEAVE TUTORIAL TRIGGER AT 0 IF NOTHING HAPPENS AFTER
    public int tutorialTrigger; //what tutorial trigger is sent after dialogue completes (don't use with options!)

    public AudioClip myMusic;   //music polayed during dialog
    public AudioClip oldMusic;  //music played after dialog- usually the same as the room was before but can be different.
}
