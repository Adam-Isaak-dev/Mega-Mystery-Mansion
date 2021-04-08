using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    //this script handles objects that can be clicked on and collected.

    [TextArea (4,8)]
    public string myInspection;      //text shown when clicked
    public bool collectable;         //true if the object can be taken into the inventory
    private Text inspectText;        //text changed to inspect text
    private GlobalVariable manager;
    private InventoryManager inventory;
    private AudioManager soundplayer;
    public int itemID;                  //item id for collectables - coralates to the inventory slot the item is added too/which item it is
    public bool isClothes;              //true if this is clothes in the wardrobe
    public bool isTutorialTrigger;      //uses id to trigger tutorial instead of give item

    private float timer;        //count down before text reset
    int i;

    private void Start()
    {
        manager = GameObject.FindWithTag("manager").GetComponent<GlobalVariable>();
        soundplayer = GameObject.FindWithTag("manager").GetComponent<AudioManager>();
        inspectText = GameObject.FindWithTag("inspectText").GetComponent<Text>();


        inventory = GameObject.FindWithTag("manager").GetComponent<InventoryManager>();
        //if its not working around here you probably disabled the inventory UI and forgot to reenable it

        if (collectable && PlayerPrefs.GetInt("item" + itemID) == 1)
            Destroy(gameObject);
    }

    private void Update()
    {
        if (timer > 0)
            timer -= Time.deltaTime;
        if (!collectable)
        {
            if (timer < 0 && inspectText.text == myInspection)
                inspectText.text = "";
        }
    }

    private void OnMouseDown()
    {//triggers when the thing is clicked
        if (manager.canClick)
        {
            Debug.Log("clicked");
            timer = 4;                              // <-- how long each inspection will last if nothing else is clicked
            if (myInspection.Length > 30)   //extra time for longer inspects
                timer += 3;
            if (myInspection.Length > 40)
                timer += 3;
            if(!collectable)
            inspectText.text = myInspection;
            if (collectable)
            {
                if (isTutorialTrigger)
                    Tutorial.instance.tutorial(itemID);
                else
                {
                    inventory.GetItem(itemID);
                    //input stuff to add it to inventory, play sound, etc. ^^
                    soundplayer.PlayClip(soundplayer.pickup);
                    inspectText.text = myInspection;
                    gameObject.SetActive(false);
                }
                cursorController.instance.normalCursor();
                //Destroy(gameObject);

            }

            if (isTutorialTrigger&&!collectable)
                Tutorial.instance.tutorial(itemID);
            //add an else to play a sound for normal inspects

            if (!collectable && isClothes)
            {
                discoEntry.instance.pickThisOutfit(itemID-1);
            }
        }

    }

    //cursors

    private void OnMouseEnter()
    {
        if(GlobalVariable.instance.canClick)
            cursorController.instance.examineCursor();
    }

    private void OnMouseExit()
    {
         cursorController.instance.normalCursor();
    }

}
