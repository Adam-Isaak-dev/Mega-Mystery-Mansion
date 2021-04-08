using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cardMenu : MonoBehaviour
{
    public Dropdown[] selections;
    public DialogueBase[] compareDia;

    public Image card;
    public Sprite[] mythPic;
    public Sprite[] paraPic;
    public Sprite[] crypPic;
    public Sprite[] hoaxPic;
    public Sprite[] jokePic;

    public DialogueBase[] responses;

    public void saveValue()
    {
        if (GlobalVariable.instance.mazeOpen==false) //dont save if not start of game
        {
            GlobalVariable.instance.cardOrigin = selections[0].value;
            if (selections[0].value != 4)
                GlobalVariable.instance.cardValue = selections[1].value;
            else
            {
                if (selections[2].value == 0)
                    GlobalVariable.instance.cardValue = 14;
                else
                    GlobalVariable.instance.cardValue = 15;
            }
        }
    }


    public void showJoker()
    {
        if(selections[0].value==4&&selections[2].gameObject.activeSelf==false)
        {
            selections[2].gameObject.SetActive(true);
            selections[1].gameObject.SetActive(false);
        }
        else
        {if (selections[2].gameObject.activeSelf)
            {
                selections[1].gameObject.SetActive(true);
                selections[2].gameObject.SetActive(false);
            }

        }
    }

    public void compareNumbers()
    {
        int origin, value;
        if (GlobalVariable.instance.mazeOpen == true)
        {//can compare cards only if not start of game
            origin = selections[0].value;
            if (selections[0].value != 4)
                value = selections[1].value;
            else
            {
                if (selections[2].value == 0)
                    value = 14;
                else
                    value = 15;
            }

            if (origin == GlobalVariable.instance.cardOrigin && value == GlobalVariable.instance.cardValue)
            {//correct
                Debug.Log("correct");
                gameObject.SetActive(false);
                DialogueManager.instance.EnqueueDialogue(responses[0]);
            }
            else
            {
                if (origin == 4 && value == 14)
                {//mdw
                    Debug.Log("MDW");
                    gameObject.SetActive(false);
                    DialogueManager.instance.EnqueueDialogue(responses[1]);
                }
                else
                {//wrong
                    Debug.Log("lose");
                    gameObject.SetActive(false);
                    DialogueManager.instance.EnqueueDialogue(responses[2]);
                }
            }
        }
        else
            Tutorial.instance.tutorial(2);
    }

    public void updateImage()
    {
        if (selections[0].value != 4) //if not a joker
        {
            switch(selections[0].value)
            {
                case 0://myth
                    card.sprite = mythPic[selections[1].value];
                    break;
                case 1://para
                    card.sprite = paraPic[selections[1].value];
                    break;
                case 2://hoax
                    card.sprite = hoaxPic[selections[1].value];
                    break;
                case 3://cryptid
                    card.sprite = crypPic[selections[1].value];
                    break;
            }
        }
        else
        {
            if (selections[2].value == 0)
                card.sprite = jokePic[0];
            else
                card.sprite = jokePic[1];
        }

        AudioManager.instance.PlayClip(AudioManager.instance.card);
    }

    public void randomizeCard()
    {
        selections[0].value = Random.Range(0, 4);
        selections[1].value = Random.Range(0, 13);
        selections[2].value = Random.Range(0, 2);
        updateImage();
    }
}
