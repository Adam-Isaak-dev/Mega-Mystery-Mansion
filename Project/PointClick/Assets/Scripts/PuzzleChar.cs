using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleChar : MonoBehaviour
{//advanced dialogue trigger for puzzle characters with more than one line

    public enum charac
    {
        chuckles,mouse,heckles,ghost,fred,screw,wood,bolt,rats
    }
    public charac character;
    public Text inspectText;

    public DialogueBase firstContact;   //when first speaking to character
    public DialogueBase[] inPuzzle;     //list of possible dialogue when you're in the puzzle
    public DialogueBase[] afterPuzzle;  //list of possible dialogue for when you've finished the puzzle

    void Start()
    {
        if(GameObject.FindWithTag("inspectText")!=null)
            inspectText = GameObject.FindWithTag("inspectText").GetComponent<Text>();
    }

    public void TriggerDialogue(DialogueBase dialogue)
    {
        DialogueManager.instance.EnqueueDialogue(dialogue);
    }

    private void OnMouseDown()
    {
        if (GlobalVariable.instance.canClick)
        {
            if(inspectText)
                inspectText.text = "";
            cursorController.instance.normalCursor();
            //=======================
            //Chuckles - kitchen
            //=======================
            if (character == charac.chuckles)
            {
                if (GlobalVariable.instance.cheeseState==0)
                {
                    TriggerDialogue(firstContact);
                    InventoryManager.instance.GetItem(29);
                    GlobalVariable.instance.cheeseState = 1;
                }
                else
                {
                    if (GlobalVariable.instance.cheeseState==2)
                        TriggerDialogue(afterPuzzle[Random.Range(0, afterPuzzle.Length)]);
                    else
                        TriggerDialogue(inPuzzle[Random.Range(0, inPuzzle.Length)]);
                }
            }
            //=======================
            //Mice - Hints
            //=======================
            if (character == charac.mouse)
            {
                if (GlobalVariable.instance.cheeseState == 2)
                  TriggerDialogue(afterPuzzle[Random.Range(0, afterPuzzle.Length)]);
                else
                  TriggerDialogue(inPuzzle[Random.Range(0, inPuzzle.Length)]);
            }
            //=======================
            //Pool Spectres
            //=======================
            if(character == charac.ghost&&GlobalVariable.instance.poolState==2)
                TriggerDialogue(afterPuzzle[Random.Range(0, afterPuzzle.Length)]);
            //=======================
            //Fred
            //=======================
            if (character == charac.fred)
            {
                if (GlobalVariable.instance.discoState == 0)
                {
                    TriggerDialogue(firstContact);
                    GlobalVariable.instance.discoState = 1;
                }
                else
                {
                    if (GlobalVariable.instance.discoState == 1)
                    {//in puzzle, check for entry
                        if(!InventoryManager.instance.hasItem[13])
                        {//no ticket
                            TriggerDialogue(inPuzzle[0]);
                        }
                        else
                        {
                            if(discoEntry.instance.equipedOutfit!=1&&!InventoryManager.instance.hasItem[26])
                            {//not right outfit
                                TriggerDialogue(inPuzzle[1]);
                            }
                            else
                            {   if (InventoryManager.instance.hasItem[26])//did quiz but puzzle not done time
                                    TriggerDialogue(inPuzzle[3]);
                                else//quiz time
                                    TriggerDialogue(inPuzzle[2]);
                            }
                        }

                    }
                    else
                        TriggerDialogue(afterPuzzle[Random.Range(0, afterPuzzle.Length)]);
                }
            }
            //=======================
            //Armour
            //=======================
            if(character == charac.screw)
            {
                if (InventoryManager.instance.hasItem[15])
                    TriggerDialogue(inPuzzle[1]);
                else
                    TriggerDialogue(inPuzzle[0]);
            }
            if (character == charac.wood)
            {
                if (InventoryManager.instance.hasItem[14])
                    TriggerDialogue(inPuzzle[1]);
                else
                    TriggerDialogue(inPuzzle[0]);
            }
            if (character == charac.bolt)
            {
                if (InventoryManager.instance.hasItem[16])
                    TriggerDialogue(inPuzzle[1]);
                else
                    TriggerDialogue(inPuzzle[0]);
            }
            //=======================
            //rat fight
            //=======================
            if (character == charac.rats)
            {
                TriggerDialogue(firstContact);
            }
      }
    }

    private void OnMouseEnter()
    {
        if (GlobalVariable.instance.canClick)
            cursorController.instance.talkingCursor();
    }

    private void OnMouseExit()
    {
        cursorController.instance.normalCursor();
    }

    private void Update()
    {
        if (character == charac.mouse && gameObject.activeSelf == true && GlobalVariable.instance.cheeseState == 0)
            gameObject.SetActive(false);
    }
}
