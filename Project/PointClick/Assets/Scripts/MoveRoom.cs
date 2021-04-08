using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveRoom : MonoBehaviour
{
    public GameObject[] hide;   //will be hidden on click
    public GameObject[] show;   //will be shown on click

    private GlobalVariable manager;
    private InventoryManager inventory;
    private Text inspectText;
    int i;                      //loop counter
    float timer;
    public bool hasKey;         //true if the door needs a key
    public bool padLock;        //true if the door has a padlock (garage only)
    public bool poolHole;       //true if a pool hole
    public int keyID;           //item id of the key if one is needed

    public AudioClip myMusic;   //music door will change to. Music will not change if it was already the track playing.
    public AudioClip mySound;   //sound played when opened, will use default if not set

    public bool noTransition;   //if true, transition effect won't be triggered, wont vanish with UI popups and music won't change.
    public bool noSound;        //no sound for normal transitions if true
    private Animator transition;

    public DialogueBase nextRoomDia;    //dialogue triggered after entering the room
    public GameObject password;

    public bool cultCall;

    private void Start()
    {
        manager = GameObject.FindWithTag("manager").GetComponent<GlobalVariable>();
        inventory = GameObject.FindWithTag("manager").GetComponent<InventoryManager>();
        inspectText = GameObject.FindWithTag("inspectText").GetComponent<Text>();
        transition = GameObject.FindWithTag("screentransition").GetComponent<Animator>();
    }
    private void Update()
    {
        //vanish with UI popups
        if(manager.canClick==false&&!noTransition)
        {
            if(gameObject.GetComponent<SpriteRenderer>())
            {
                if (gameObject.GetComponent<SpriteRenderer>().enabled == true)
                    gameObject.GetComponent<SpriteRenderer>().enabled = false;
            }
        }
        else
        {
            if (gameObject.GetComponent<SpriteRenderer>())
            {
                if(gameObject.GetComponent<SpriteRenderer>().enabled==false)
                gameObject.GetComponent<SpriteRenderer>().enabled = true;
            }
        }

        if (timer > 0)
            timer -= Time.deltaTime;
        if (timer < 0 && (inspectText.text == "Locked, I’ll need to find some way to open it." || inspectText.text == "Locked up tight, I’ll need a key to get in."
            || inspectText.text == "Damn, it’s locked." || inspectText.text == "Locked. Who even locks doors inside the house anyway?"|| inspectText.text=="Locked… Of course."))
            inspectText.text = "";
    }
    private void OnMouseDown()
    {
        if (manager.canClick)
        {
            if (hasKey)
            {
                if(inventory.hasItem[keyID])
                {
                    if (!noTransition)
                    {
                        StartCoroutine(Transition());
                        if (manager.doorCooldown <= 0)
                            manager.doorCooldown = 1.2f;
                    }
                    else
                    {
                        if (mySound != null&&!noSound)
                            AudioManager.instance.PlayClip(mySound);
                        for (i = 0; i < hide.Length; i++)
                                hide[i].SetActive(false);
                        for (i = 0; i < show.Length; i++)
                            show[i].SetActive(true);
                        inspectText.text = "";
                        cursorController.instance.normalCursor();
                    }
                }
                else
                {
                    timer = 4;
                    if(!noSound)
                        AudioManager.instance.PlayClip(AudioManager.instance.doorLocked);
                    switch (Random.Range(0,5))
                    {
                        case 0: inspectText.text = "Locked, I’ll need to find some way to open it."; break;
                        case 1: inspectText.text = "Locked up tight, I’ll need a key to get in."; break;
                        case 2: inspectText.text = "Dang it! It’s locked."; break;
                        case 3: inspectText.text = "Locked… Of course."; break;
                        case 4: inspectText.text = "Locked. Who even locks doors inside the house anyway?"; break;
                    }
                    
                }
            }
            else
            {
                if (padLock&&GlobalVariable.instance.garageOpen!=true)
                {//open padlock ui
                    password.SetActive(true);
                }
                else
                {
                    if (!noTransition)
                    {
                        StartCoroutine(Transition());
                        if (manager.doorCooldown <= 0)
                            manager.doorCooldown = 1.2f;
                    }
                    else
                    {
                        if (mySound != null&&!noSound)
                           AudioManager.instance.PlayClip(mySound);

                        for (i = 0; i < hide.Length; i++)
                            hide[i].SetActive(false);
                        for (i = 0; i < show.Length; i++)
                            show[i].SetActive(true);
                        if (poolHole && ballScreen.instance)
                        {
                            ballScreen.instance.changeHoleID(keyID);
                            ballScreen.instance.updateImages();
                        }
                        inspectText.text = "";
                        cursorController.instance.normalCursor();
                    }
                }
            }
        }

    }

    IEnumerator Transition()
    {
        if (manager.doorCooldown <= 0)
        {
            Cursor.visible = false;
            transition.SetTrigger("Change");
            yield return new WaitForSeconds(1.2f);
            if (!noSound)
            {
                if (mySound != null)
                    AudioManager.instance.PlayClip(mySound);
                else
                    AudioManager.instance.PlayClip(AudioManager.instance.doorOpen);
            }
            for (i = 0; i < hide.Length; i++)
                hide[i].SetActive(false);
            cursorController.instance.normalCursor();
            MusicManager.instance.changeBGM(myMusic);
            for (i = 0; i < show.Length; i++)
                show[i].SetActive(true);
            inspectText.text = "";
            transition.SetTrigger("Change2");
            if (!nextRoomDia)
                Cursor.visible = true;
            yield return new WaitForSeconds(0.55f);
            if (nextRoomDia)
            {
                manager.canClick = false;
                DialogueManager.instance.EnqueueDialogue(nextRoomDia);
                Cursor.visible = true;
            }
            if(cultCall)
                GlobalVariable.instance.cultState = 2;
        }
        
    }

    public void remoteCall()
    {
        StartCoroutine(Transition());
    }

    private void OnMouseOver()
    {
        if(!noTransition&&manager.canClick)
            cursorController.instance.movingCursor();
        else
        {
            if (noTransition && manager.canClick)
                cursorController.instance.examineCursor();
        }
    }

    private void OnMouseExit()
    {
        cursorController.instance.normalCursor();
    }
}
