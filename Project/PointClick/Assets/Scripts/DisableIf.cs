using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisableIf : MonoBehaviour
{
    //for disabling buttons if certain stuff is true

    public Button me;      //the button
    public GameObject me2; //hide non-buttons
    public GameObject[] show;   //things, like a message, that are shown when the button is disabled

    public Color normal;
    public Color disabled;

    public bool ifNoGame;  //disable if a new game would start - for deleting progress
    public bool doneCheese;//disable if the cheese puzzle has been complete
    public bool isGaragePuzzle;//disable garage puzzle's stuff if the disco hasnt been complete
    public bool isGarageTrigger;
    public bool isLibraryDoor;
    public bool isCultRoom;
    public bool KChuckles;
    public bool birdBook;

    public bool isSkeleDisco;//trigger dialogue for skeleboi puzzle
    public DialogueBase discoPuzzle;

    int i;

    void Update()
    {
        if(ifNoGame)
        {
            if (me.interactable == false && (PlayerPrefs.GetInt("isGame") == 1))
            {
                me.interactable = true;
                for (i = 0; i < show.Length; i++)
                    show[i].SetActive(false);
            }
            if (me.interactable == true && (PlayerPrefs.GetInt("isGame") != 1))
            {
                me.interactable = false;
                for (i = 0; i < show.Length; i++)
                    show[i].SetActive(true);
            }
        }

        if(doneCheese)
        {
            if (GlobalVariable.instance.cheeseState==2&&me2.activeSelf==true)
                me2.SetActive(false);
        }

        if(isSkeleDisco)
        {
            if (GlobalVariable.instance.discoState != 2)
            {
                GlobalVariable.instance.discoState = 2;
                DialogueManager.instance.EnqueueDialogue(discoPuzzle);
            }

        }

        if(isGaragePuzzle)
        {
            if (GlobalVariable.instance.discoState != 2 && me2.activeSelf)
            {
                me2.SetActive(false);
            }
            else if (me2.activeSelf == false && GlobalVariable.instance.discoState == 2)
            {
                me2.SetActive(true);
            }
        }

        if (isGarageTrigger)
        {
            if (GlobalVariable.instance.garageState > 0 && me2.activeSelf == true)
                me2.SetActive(false);

            else
                if (me2.activeSelf == false && GlobalVariable.instance.garageState == 0)
                    me2.SetActive(true);
        }

        if(isLibraryDoor)
        {
            if (GlobalVariable.instance.mazeOpen)
            {
                me2.SetActive(false);
                for (i = 0; i < show.Length; i++)
                    show[i].SetActive(true);
            }
            else
            {
                me2.SetActive(true);
                for (i = 0; i < show.Length; i++)
                    show[i].SetActive(false);
            }
        }

        if(isCultRoom)
        {
            if(GlobalVariable.instance.cultState==0)
            {
                Tutorial.instance.tutorial(22);
            }
            if(GlobalVariable.instance.cultState==2)
            {
                GlobalVariable.instance.cultState = 1;
                Tutorial.instance.tutorial(30);
            }
        }

        if(KChuckles)
        {
            if (GlobalVariable.instance.cultState == 2&&me2.activeSelf)
            {
                me2.SetActive(false);
                for (i = 0; i < show.Length; i++)
                    show[i].SetActive(true);
            }
            else
            {
                if (me2.activeSelf == false&& GlobalVariable.instance.cultState != 2)
                {
                    me2.SetActive(true);
                    for (i = 0; i < show.Length; i++)
                        show[i].SetActive(false);
                }

            }
        }

        if (birdBook)
        {
            if (GlobalVariable.instance.canClick)
                GlobalVariable.instance.canClick = false;
        }
    }
}
