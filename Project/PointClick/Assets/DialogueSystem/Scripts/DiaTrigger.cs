using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiaTrigger : MonoBehaviour
{
    //this script triggers dialogue, sorry for the placeholder name

    public DialogueBase dialogue;
    private GlobalVariable manager;
    private Text inspectText;

    private void Start()
    {
        manager = GameObject.FindWithTag("manager").GetComponent<GlobalVariable>();
        inspectText = GameObject.FindWithTag("inspectText").GetComponent<Text>();
    }

    public void TriggerDialogue()
    {
        DialogueManager.instance.EnqueueDialogue(dialogue);
    }

    private void OnMouseDown()
    {
        if (manager.canClick)
        {
            TriggerDialogue();
            inspectText.text = "";
            cursorController.instance.normalCursor();
        }
    }

    private void OnMouseEnter()
    {
        if(manager.canClick)
        cursorController.instance.talkingCursor();
    }

    private void OnMouseExit()
    {
        cursorController.instance.normalCursor();
    }
}
