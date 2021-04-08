using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "New DialogueOption", menuName = "DialogueOptions")]

public class DialogueOptions : DialogueBase
{
    [TextArea(2, 10)]
    public string questionText;

    [System.Serializable]
   public class Options
    {
        public DialogueBase nextDialogue;
        public string buttonName;
        public UnityEvent myEvent;
    }
    public Options[] optionsInfo;
}
