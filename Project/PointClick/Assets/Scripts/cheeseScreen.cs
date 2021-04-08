using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cheeseScreen : MonoBehaviour
{
    public static cheeseScreen instance;

    public Dropdown[] choices;
    int correct;
    bool emptySpot;

    public DialogueBase emptyTalk;  //if theres an empty plate
    public DialogueBase correctTalk;//if everything is right
    public DialogueBase badTalk;    //something is wrong

    public PuzzleChar character;
    public GameObject platter;

    private int i;

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
    }

    private void Update()
    {
        if (gameObject.activeSelf && GlobalVariable.instance.canClick)
            GlobalVariable.instance.canClick = false;
    }

    public void checkChoices()
    {
        correct = 0;
        emptySpot = false;
        int i;
        //make sure no blank
        for(i=0;i<choices.Length;i++)
        {
            if (choices[i].value == 0)
                emptySpot = true;
        }
        if (!emptySpot)
        {//check values of all (placehold values rn)
            if (choices[0].value == 1)
            {//correct
                correct++;
                Debug.Log("correct");
            }
            if (choices[1].value == 2)
            {//correct
                correct++;
                Debug.Log("correct");
            }
            if (choices[2].value == 3)
            {//correct
                correct++;
                Debug.Log("correct");
            }
            if (choices[3].value == 4)
            {//correct
                correct++;
                Debug.Log("correct");
            }
            if (choices[4].value == 5)
            {//correct
                correct++;
                Debug.Log("correct");
            }
            if (choices[5].value == 6)
            {//correct
                correct++;
                Debug.Log("correct");
            }
            if (choices[6].value == 7)
            {//correct
                correct++;
                Debug.Log("correct");
            }
            if (choices[7].value == 8)
            {//correct
                correct++;
                Debug.Log("correct");
            }


            //check if won
            if (correct == choices.Length)
            {//wow they got it
                Debug.Log("cheese is the good");
                DialogueManager.instance.EnqueueDialogue(correctTalk);
                platter.SetActive(false);
                gameObject.SetActive(false);
                GlobalVariable.instance.cheeseState = 2;

                for (i = 0; i < GlobalVariable.instance.tableCheese.Length; i++)
                    GlobalVariable.instance.tableCheese[i].enabled = true;
            }
            else
            {
                DialogueManager.instance.EnqueueDialogue(badTalk);
                Debug.Log("No");
                gameObject.SetActive(false);
            }
        }
        else
        {//there is at least 1 empty spot
         //add stuff for chuckles to yell at you or something
            DialogueManager.instance.EnqueueDialogue(emptyTalk);
            Debug.Log("a plate is empty somewhere");
            gameObject.SetActive(false);
        }

    }
}
