using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using UnityEngine.Events;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{

    public static DialogueManager instance;
    private GlobalVariable manager;
    

    private void Awake()
    {
       if (instance != null)
        {
            Debug.LogWarning("fix this" + gameObject.name);
        }
       else
        {
            instance = this;
        }
    }

    public GameObject dialogueBox;

    public AudioClip myMusic;
    public AudioClip oldMusic;

    public Text dialogueText;
    public Text dialogueName;
    public Image dialoguePortrait;
    public float delay = 0.001f;

    public Queue<DialogueBase.Info> dialogueInfo; //first in first out collection (remembers order)

    private bool isCurrentlyTyping;
    private string completeText;

    private int tutorialTrigger;    //what happens after the dialog, taken from db

    //options stuff
    private bool isDialogueOption;
    public GameObject dialogueOptionUI;
    public bool inDialogue;
    public GameObject[] optionsButtons;
    public int optionsAmount;
    public Text questionText;

    StringBuilder sb = new StringBuilder();
    public string StartTag { get; set; }
    public string EndTag { get; set; }
    public string BodyToPrint { get; set; }
    public bool IsRichText { get; set; }
    public int AmountToRich { get; set; }
    public int RichTextIndex { get; set; }

    public void Start()
    {
        dialogueInfo = new Queue<DialogueBase.Info>();
        manager = GameObject.FindWithTag("manager").GetComponent<GlobalVariable>();
    }

    public void EnqueueDialogue(DialogueBase db)
    {
        if (inDialogue) return; //stops if in dialogue
        inDialogue = true;
        manager.canClick = false;
        myMusic = db.myMusic;
        oldMusic = db.oldMusic;
        tutorialTrigger = db.tutorialTrigger;
        MusicManager.instance.changeBGM(myMusic);

        dialogueBox.SetActive(true);
        dialogueInfo.Clear();

        OptionsParser(db);
        
        foreach(DialogueBase.Info info in db.dialogueInfo)
        {
            dialogueInfo.Enqueue(info);
        }

        DequeueDialogue();
    }

    public void DequeueDialogue()
    {
        
        if (isCurrentlyTyping)
        {
            CompleteText();
            StopAllCoroutines();  //might be cause of issue with other coroutines if any are added
            isCurrentlyTyping = false;
            return;
        }

        if (dialogueInfo.Count==0)
        {
            EndOfDialogue();
            return;
        }

        DialogueBase.Info info = dialogueInfo.Dequeue();
        completeText = info.myText;
 


        dialogueName.text = info.character.myName;
        dialogueText.text = info.myText;
        info.ChangeEmotion();
        dialoguePortrait.sprite = info.character.MyPortrait;

        dialogueText.text = "";
        StartCoroutine(TypeText(info));
    }

    IEnumerator TypeText(DialogueBase.Info info)  //types text
    {
        ResetVariables();
        BodyToPrint = info.myText;
        isCurrentlyTyping = true;
        for (int i = 0;i< BodyToPrint.Length; i++)
        {
            yield return new WaitForSeconds(delay);
            AudioManager.instance.PlayClip(info.character.myVoice); //might be in wrong spot

            if (BodyToPrint[i]=='<')
            {
                IsRichText = true;
                RichTextIndex = 0;
                RichTextParser.GetRichTextValue(info.myText);
            }

            if(IsRichText)//print rich text (bold or whatever)
            {
                if (RichTextIndex < AmountToRich)
                {
                    sb.Append(StartTag + BodyToPrint[i] + EndTag); //individually riches each character as printed (i think?)
                    RichTextIndex++;
                }
                else
                {
                    IsRichText = false;
                }
            }

            if(!IsRichText)//print normal
            {
                sb.Append(BodyToPrint[i]);
            }
            dialogueText.text = sb.ToString();
        }
        isCurrentlyTyping = false;
    }

    private void CompleteText()
    {
        dialogueText.text = completeText;
    }

    public void EndOfDialogue()
    {
        dialogueBox.SetActive(false);
        OptionsLogic();
    }

    public void ResetVariables()
    {
        dialogueText.text = "";
        sb.Length = 0;
        RichTextIndex = 0;
        IsRichText = false;
        AmountToRich = 0;
        RichTextParser.CurrentIndex = 0;
    }

    private void OptionsLogic()
    {
        if (isDialogueOption == true) //turn parent on
        {
            dialogueOptionUI.SetActive(true);
            
        }
        else
        {
            inDialogue = false;
            manager.canClick = true;
            MusicManager.instance.changeBGM(oldMusic);
            if(tutorialTrigger!=0)
                Tutorial.instance.tutorial(tutorialTrigger);
        }
    }

    public void closeOptions()
    {
        dialogueOptionUI.SetActive(false);
        MusicManager.instance.changeBGM(oldMusic);
    }

    private void OptionsParser(DialogueBase db)
    {
        if (db is DialogueOptions)
        {
            isDialogueOption = true;
            DialogueOptions dialogueOptions = db as DialogueOptions;
            optionsAmount = dialogueOptions.optionsInfo.Length;
            questionText.text = dialogueOptions.questionText;
            for (int i = 0; i < optionsButtons.Length; i++)
            {
                optionsButtons[i].SetActive(false);
            }

            for (int i = 0; i < optionsAmount; i++)//show right # of buttons, not displayed yet
            {
                optionsButtons[i].SetActive(true);
                optionsButtons[i].transform.GetChild(0).gameObject.GetComponent<Text>().text = dialogueOptions.optionsInfo[i].buttonName;
                UnityEventHandler myEventHandler = optionsButtons[i].GetComponent<UnityEventHandler>();
                myEventHandler.eventHandler = dialogueOptions.optionsInfo[i].myEvent;
                if (dialogueOptions.optionsInfo[i].nextDialogue != null)
                {
                    myEventHandler.myDialogue = dialogueOptions.optionsInfo[i].nextDialogue;
                }
                else
                {
                    myEventHandler.myDialogue = null;
                }
            }
        }
        else
        {
            isDialogueOption = false;
        }
    }
}
