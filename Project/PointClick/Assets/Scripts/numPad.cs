using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class numPad : MonoBehaviour
{

    public Text myText;
    public Text comment;
    private int numCount;
    public int[] pass;
    public GameObject inventory;
    public Image buzzer;

    private float timer;

    private void Start()
    {
        numCount = 0;
        myText.text = "";
    }

    public void Awake()
    {
        if (!InventoryManager.instance.hasItem[25])
        {//first puzzle, dismiss the padlock
            comment.text = "A padlock? I should probably focus on the regular locks first...";
        }
        else//add more later, yada yada
            comment.text = "Lets see... if I were a password, what would I be? That Fred guy mentioned something about the guest rooms...";
    }

    private void Update()
    {
        if (gameObject.activeSelf && GlobalVariable.instance.canClick)
            GlobalVariable.instance.canClick = false;

        if (timer < 0)
            buzzer.color = new Color(255, 255, 255, 0.58f);
        else
            timer -= Time.deltaTime;

        //comments so the player knows to ignore it early on
        if (!InventoryManager.instance.hasItem[25]&&comment.text!= "A padlock? I should probably focus on the regular locks first...")
            comment.text = "A padlock? I should probably focus on the regular locks first...";
        else
        if (InventoryManager.instance.hasItem[25] && comment.text != "Lets see... if I were a password, what would I be?")
        comment.text = "Lets see... if I were a password, what would I be? That Fred guy mentioned something about the guest rooms...";
    }

    public void addNum(int num)
    {
        if (numCount < 3)
        {
            AudioManager.instance.PlayClip(AudioManager.instance.tik);
            myText.text = myText.text + "*";
            pass[numCount] = num;
            numCount++;
        }
        //add an else to play a deny sound
    }

    public void clearNum()
    {
        numCount = 0;
        myText.text = "";
        pass[0] = 0;    //stops some errors
    }

    public void checkNum()
    {
        if(pass[0]==4&&pass[1]==7&&pass[2]==2)
        {
            Debug.Log("password correct!");
            buzzer.color = new Color(0, 255, 0, 0.58f);
            GlobalVariable.instance.garageOpen = true;
            gameObject.SetActive(false);
            GlobalVariable.instance.canClick = true;
            inventory.SetActive(true);
            AudioManager.instance.PlayClip(AudioManager.instance.confirm);
        }
        else
        {
            buzzer.color = new Color(220, 0, 0, 0.58f);
            timer = 2;
            clearNum();
        }
    }
}
