using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ballScreen : MonoBehaviour
{
    public static ballScreen instance;

    //sprite for balls
    public GameObject[] bagBalls;
    public GameObject[] holeBalls;

    public Menu menu;
    public Text comment;

    //what hole is this
    int holeID; //0-5

    //data for holes
    public int[] hole1;
    public int[] hole2;
    public int[] hole3;
    public int[] hole4;
    public int[] hole5;
    public int[] hole6;

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

    public void updateImages()
    {
        int i;

        switch(holeID)
        {
            case 0: comment.text = "'January and July' is scratched onto the side of the cup."; break;
            case 1: comment.text = "'March and May' is crudely written on the bottom."; break;
            case 2: comment.text = "Somebody wrote 'April and December' inside this cup."; break;
            case 3: comment.text = "There are words written on the rim of this cup:'June and October.'"; break;
            case 4: comment.text = "There are numbers scratched on the table beside the cup, 'February and November.'"; break;
            case 5: comment.text = "Right on the bottom of this somebody wrote 'August and September.'"; break;
        }

        //bag images
        for(i=0;i<bagBalls.Length;i++)
        {
            if(InventoryManager.instance.hasItem[i+1])
                bagBalls[i].SetActive(true);
            else
                bagBalls[i].SetActive(false);
        }

        //hole ball images
        switch (holeID)
        {
            case 0:
                for (i=0;i<holeBalls.Length;i++)
                {
                    holeBalls[i].GetComponent<Image>().enabled = true;
                    switch(hole1[i])
                    {
                        case 0:
                            holeBalls[i].GetComponent<Image>().sprite = bagBalls[0].GetComponent<Image>().sprite;
                            break;
                        case 1:
                            holeBalls[i].GetComponent<Image>().sprite = bagBalls[1].GetComponent<Image>().sprite;
                            break;
                        case 2:
                            holeBalls[i].GetComponent<Image>().sprite = bagBalls[2].GetComponent<Image>().sprite;
                            break;
                        case 3:
                            holeBalls[i].GetComponent<Image>().sprite = bagBalls[3].GetComponent<Image>().sprite;
                            break;
                        case 4:
                            holeBalls[i].GetComponent<Image>().sprite = bagBalls[4].GetComponent<Image>().sprite;
                            break;
                        case 5:
                            holeBalls[i].GetComponent<Image>().sprite = bagBalls[5].GetComponent<Image>().sprite;
                            break;
                        case 6:
                            holeBalls[i].GetComponent<Image>().sprite = bagBalls[6].GetComponent<Image>().sprite;
                            break;
                        case 7:
                            holeBalls[i].GetComponent<Image>().sprite = bagBalls[7].GetComponent<Image>().sprite;
                            break;
                        case 8:
                            holeBalls[i].GetComponent<Image>().sprite = bagBalls[8].GetComponent<Image>().sprite;
                            break;
                        case 9:
                            holeBalls[i].GetComponent<Image>().sprite = bagBalls[9].GetComponent<Image>().sprite;
                            break;
                        case 10:
                            holeBalls[i].GetComponent<Image>().sprite = bagBalls[10].GetComponent<Image>().sprite;
                            break;
                        case 11:
                            holeBalls[i].GetComponent<Image>().sprite = bagBalls[11].GetComponent<Image>().sprite;
                            break;
                        case 12:
                            holeBalls[i].GetComponent<Image>().sprite = bagBalls[12].GetComponent<Image>().sprite;
                            break;
                        case 13:
                            holeBalls[i].GetComponent<Image>().enabled = false;
                            break;
                    }
                }
                break;
            case 1:
                for (i = 0; i < holeBalls.Length; i++)
                {
                    holeBalls[i].GetComponent<Image>().enabled = true;
                    switch (hole2[i])
                    {
                        case 0:
                            holeBalls[i].GetComponent<Image>().sprite = bagBalls[0].GetComponent<Image>().sprite;
                            break;
                        case 1:
                            holeBalls[i].GetComponent<Image>().sprite = bagBalls[1].GetComponent<Image>().sprite;
                            break;
                        case 2:
                            holeBalls[i].GetComponent<Image>().sprite = bagBalls[2].GetComponent<Image>().sprite;
                            break;
                        case 3:
                            holeBalls[i].GetComponent<Image>().sprite = bagBalls[3].GetComponent<Image>().sprite;
                            break;
                        case 4:
                            holeBalls[i].GetComponent<Image>().sprite = bagBalls[4].GetComponent<Image>().sprite;
                            break;
                        case 5:
                            holeBalls[i].GetComponent<Image>().sprite = bagBalls[5].GetComponent<Image>().sprite;
                            break;
                        case 6:
                            holeBalls[i].GetComponent<Image>().sprite = bagBalls[6].GetComponent<Image>().sprite;
                            break;
                        case 7:
                            holeBalls[i].GetComponent<Image>().sprite = bagBalls[7].GetComponent<Image>().sprite;
                            break;
                        case 8:
                            holeBalls[i].GetComponent<Image>().sprite = bagBalls[8].GetComponent<Image>().sprite;
                            break;
                        case 9:
                            holeBalls[i].GetComponent<Image>().sprite = bagBalls[9].GetComponent<Image>().sprite;
                            break;
                        case 10:
                            holeBalls[i].GetComponent<Image>().sprite = bagBalls[10].GetComponent<Image>().sprite;
                            break;
                        case 11:
                            holeBalls[i].GetComponent<Image>().sprite = bagBalls[11].GetComponent<Image>().sprite;
                            break;
                        case 12:
                            holeBalls[i].GetComponent<Image>().sprite = bagBalls[12].GetComponent<Image>().sprite;
                            break;
                        case 13:
                            holeBalls[i].GetComponent<Image>().enabled = false;
                            break;
                    }
                }
                break;
            case 2:
                for (i = 0; i < holeBalls.Length; i++)
                {
                    holeBalls[i].GetComponent<Image>().enabled = true;
                    switch (hole3[i])
                    {
                        case 0:
                            holeBalls[i].GetComponent<Image>().sprite = bagBalls[0].GetComponent<Image>().sprite;
                            break;
                        case 1:
                            holeBalls[i].GetComponent<Image>().sprite = bagBalls[1].GetComponent<Image>().sprite;
                            break;
                        case 2:
                            holeBalls[i].GetComponent<Image>().sprite = bagBalls[2].GetComponent<Image>().sprite;
                            break;
                        case 3:
                            holeBalls[i].GetComponent<Image>().sprite = bagBalls[3].GetComponent<Image>().sprite;
                            break;
                        case 4:
                            holeBalls[i].GetComponent<Image>().sprite = bagBalls[4].GetComponent<Image>().sprite;
                            break;
                        case 5:
                            holeBalls[i].GetComponent<Image>().sprite = bagBalls[5].GetComponent<Image>().sprite;
                            break;
                        case 6:
                            holeBalls[i].GetComponent<Image>().sprite = bagBalls[6].GetComponent<Image>().sprite;
                            break;
                        case 7:
                            holeBalls[i].GetComponent<Image>().sprite = bagBalls[7].GetComponent<Image>().sprite;
                            break;
                        case 8:
                            holeBalls[i].GetComponent<Image>().sprite = bagBalls[8].GetComponent<Image>().sprite;
                            break;
                        case 9:
                            holeBalls[i].GetComponent<Image>().sprite = bagBalls[9].GetComponent<Image>().sprite;
                            break;
                        case 10:
                            holeBalls[i].GetComponent<Image>().sprite = bagBalls[10].GetComponent<Image>().sprite;
                            break;
                        case 11:
                            holeBalls[i].GetComponent<Image>().sprite = bagBalls[11].GetComponent<Image>().sprite;
                            break;
                        case 12:
                            holeBalls[i].GetComponent<Image>().sprite = bagBalls[12].GetComponent<Image>().sprite;
                            break;
                        case 13:
                            holeBalls[i].GetComponent<Image>().enabled = false;
                            break;
                    }
                }
                break;
            case 3:
                for (i = 0; i < holeBalls.Length; i++)
                {
                    holeBalls[i].GetComponent<Image>().enabled = true;
                    switch (hole4[i])
                    {
                        case 0:
                            holeBalls[i].GetComponent<Image>().sprite = bagBalls[0].GetComponent<Image>().sprite;
                            break;
                        case 1:
                            holeBalls[i].GetComponent<Image>().sprite = bagBalls[1].GetComponent<Image>().sprite;
                            break;
                        case 2:
                            holeBalls[i].GetComponent<Image>().sprite = bagBalls[2].GetComponent<Image>().sprite;
                            break;
                        case 3:
                            holeBalls[i].GetComponent<Image>().sprite = bagBalls[3].GetComponent<Image>().sprite;
                            break;
                        case 4:
                            holeBalls[i].GetComponent<Image>().sprite = bagBalls[4].GetComponent<Image>().sprite;
                            break;
                        case 5:
                            holeBalls[i].GetComponent<Image>().sprite = bagBalls[5].GetComponent<Image>().sprite;
                            break;
                        case 6:
                            holeBalls[i].GetComponent<Image>().sprite = bagBalls[6].GetComponent<Image>().sprite;
                            break;
                        case 7:
                            holeBalls[i].GetComponent<Image>().sprite = bagBalls[7].GetComponent<Image>().sprite;
                            break;
                        case 8:
                            holeBalls[i].GetComponent<Image>().sprite = bagBalls[8].GetComponent<Image>().sprite;
                            break;
                        case 9:
                            holeBalls[i].GetComponent<Image>().sprite = bagBalls[9].GetComponent<Image>().sprite;
                            break;
                        case 10:
                            holeBalls[i].GetComponent<Image>().sprite = bagBalls[10].GetComponent<Image>().sprite;
                            break;
                        case 11:
                            holeBalls[i].GetComponent<Image>().sprite = bagBalls[11].GetComponent<Image>().sprite;
                            break;
                        case 12:
                            holeBalls[i].GetComponent<Image>().sprite = bagBalls[12].GetComponent<Image>().sprite;
                            break;
                        case 13:
                            holeBalls[i].GetComponent<Image>().enabled = false;
                            break;
                    }
                }
                break;
            case 4:
                for (i = 0; i < holeBalls.Length; i++)
                {
                    holeBalls[i].GetComponent<Image>().enabled = true;
                    switch (hole5[i])
                    {
                        case 0:
                            holeBalls[i].GetComponent<Image>().sprite = bagBalls[0].GetComponent<Image>().sprite;
                            break;
                        case 1:
                            holeBalls[i].GetComponent<Image>().sprite = bagBalls[1].GetComponent<Image>().sprite;
                            break;
                        case 2:
                            holeBalls[i].GetComponent<Image>().sprite = bagBalls[2].GetComponent<Image>().sprite;
                            break;
                        case 3:
                            holeBalls[i].GetComponent<Image>().sprite = bagBalls[3].GetComponent<Image>().sprite;
                            break;
                        case 4:
                            holeBalls[i].GetComponent<Image>().sprite = bagBalls[4].GetComponent<Image>().sprite;
                            break;
                        case 5:
                            holeBalls[i].GetComponent<Image>().sprite = bagBalls[5].GetComponent<Image>().sprite;
                            break;
                        case 6:
                            holeBalls[i].GetComponent<Image>().sprite = bagBalls[6].GetComponent<Image>().sprite;
                            break;
                        case 7:
                            holeBalls[i].GetComponent<Image>().sprite = bagBalls[7].GetComponent<Image>().sprite;
                            break;
                        case 8:
                            holeBalls[i].GetComponent<Image>().sprite = bagBalls[8].GetComponent<Image>().sprite;
                            break;
                        case 9:
                            holeBalls[i].GetComponent<Image>().sprite = bagBalls[9].GetComponent<Image>().sprite;
                            break;
                        case 10:
                            holeBalls[i].GetComponent<Image>().sprite = bagBalls[10].GetComponent<Image>().sprite;
                            break;
                        case 11:
                            holeBalls[i].GetComponent<Image>().sprite = bagBalls[11].GetComponent<Image>().sprite;
                            break;
                        case 12:
                            holeBalls[i].GetComponent<Image>().sprite = bagBalls[12].GetComponent<Image>().sprite;
                            break;
                        case 13:
                            holeBalls[i].GetComponent<Image>().enabled = false;
                            break;
                    }
                }
                break;
            case 5:
                for (i = 0; i < holeBalls.Length; i++)
                {
                    holeBalls[i].GetComponent<Image>().enabled = true;
                    switch (hole6[i])
                    {
                        case 0:
                            holeBalls[i].GetComponent<Image>().sprite = bagBalls[0].GetComponent<Image>().sprite;
                            break;
                        case 1:
                            holeBalls[i].GetComponent<Image>().sprite = bagBalls[1].GetComponent<Image>().sprite;
                            break;
                        case 2:
                            holeBalls[i].GetComponent<Image>().sprite = bagBalls[2].GetComponent<Image>().sprite;
                            break;
                        case 3:
                            holeBalls[i].GetComponent<Image>().sprite = bagBalls[3].GetComponent<Image>().sprite;
                            break;
                        case 4:
                            holeBalls[i].GetComponent<Image>().sprite = bagBalls[4].GetComponent<Image>().sprite;
                            break;
                        case 5:
                            holeBalls[i].GetComponent<Image>().sprite = bagBalls[5].GetComponent<Image>().sprite;
                            break;
                        case 6:
                            holeBalls[i].GetComponent<Image>().sprite = bagBalls[6].GetComponent<Image>().sprite;
                            break;
                        case 7:
                            holeBalls[i].GetComponent<Image>().sprite = bagBalls[7].GetComponent<Image>().sprite;
                            break;
                        case 8:
                            holeBalls[i].GetComponent<Image>().sprite = bagBalls[8].GetComponent<Image>().sprite;
                            break;
                        case 9:
                            holeBalls[i].GetComponent<Image>().sprite = bagBalls[9].GetComponent<Image>().sprite;
                            break;
                        case 10:
                            holeBalls[i].GetComponent<Image>().sprite = bagBalls[10].GetComponent<Image>().sprite;
                            break;
                        case 11:
                            holeBalls[i].GetComponent<Image>().sprite = bagBalls[11].GetComponent<Image>().sprite;
                            break;
                        case 12:
                            holeBalls[i].GetComponent<Image>().sprite = bagBalls[12].GetComponent<Image>().sprite;
                            break;
                        case 13:
                            holeBalls[i].GetComponent<Image>().enabled = false;
                            break;
                    }
                }
                break;
        }
    }

    private void Update()
    {
        if (gameObject.activeSelf && GlobalVariable.instance.canClick)
        {
            GlobalVariable.instance.canClick = false;
            updateImages();
        }
    }

    public void removeFromHole(int id)
    {
        AudioManager.instance.PlayClip(AudioManager.instance.tik);
        switch (holeID)
        {
            case 0:
                InventoryManager.instance.GetItem(hole1[id] + 1);
                hole1[id] = 13;
                updateImages();
                break;
            case 1:
                InventoryManager.instance.GetItem(hole2[id] + 1);
                hole2[id] = 13;
                updateImages();
                break;
            case 2:
                InventoryManager.instance.GetItem(hole3[id] + 1);
                hole3[id] = 13;
                updateImages();
                break;
            case 3:
                InventoryManager.instance.GetItem(hole4[id] + 1);
                hole4[id] = 13;
                updateImages();
                break;
            case 4:
                InventoryManager.instance.GetItem(hole5[id] + 1);
                hole5[id] = 13;
                updateImages();
                break;
            case 5:
                InventoryManager.instance.GetItem(hole6[id] + 1);
                hole6[id] = 13;
                updateImages();
                break;
        }
    }

    public void addToHole(int id)   //item id
    {
        AudioManager.instance.PlayClip(AudioManager.instance.tik);
        switch (holeID)
        {
            case 0://hole 1
                if (hole1[0] == 13)
                {
                    InventoryManager.instance.RemoveItem(id);
                    bagBalls[id - 1].SetActive(false);
                    hole1[0] = id-1;
                    updateImages();
                }
                else
                    if(hole1[1]==13)
                    {
                        InventoryManager.instance.RemoveItem(id);
                        bagBalls[id - 1].SetActive(false);
                        hole1[1] = id - 1;
                        updateImages();
                    }
                    else
                    if (hole1[2] == 13)
                    {
                        InventoryManager.instance.RemoveItem(id);
                        bagBalls[id - 1].SetActive(false);
                        hole1[2] = id - 1;
                        updateImages();
                    }
                    else
                    {
                        InventoryManager.instance.RemoveItem(id);
                        bagBalls[id - 1].SetActive(false);
                        InventoryManager.instance.GetItem(hole1[0]+1);
                        hole1[0] = id - 1;
                        updateImages();
                    }
                break;
            case 1://hole 2
                if (hole2[0] == 13)
                {
                    InventoryManager.instance.RemoveItem(id);
                    bagBalls[id - 1].SetActive(false);
                    hole2[0] = id - 1;
                    updateImages();
                }
                else
                    if (hole2[1] == 13)
                {
                    InventoryManager.instance.RemoveItem(id);
                    bagBalls[id - 1].SetActive(false);
                    hole2[1] = id - 1;
                    updateImages();
                }
                else
                    if (hole2[2] == 13)
                {
                    InventoryManager.instance.RemoveItem(id);
                    bagBalls[id - 1].SetActive(false);
                    hole2[2] = id - 1;
                    updateImages();
                }
                else
                {
                    InventoryManager.instance.RemoveItem(id);
                    bagBalls[id - 1].SetActive(false);
                    InventoryManager.instance.GetItem(hole2[0] + 1);
                    hole2[0] = id - 1;
                    updateImages();
                }
                break;
            case 2://hole 3
                if (hole3[0] == 13)
                {
                    InventoryManager.instance.RemoveItem(id);
                    bagBalls[id - 1].SetActive(false);
                    hole3[0] = id - 1;
                    updateImages();
                }
                else
                    if (hole3[1] == 13)
                {
                    InventoryManager.instance.RemoveItem(id);
                    bagBalls[id - 1].SetActive(false);
                    hole3[1] = id - 1;
                    updateImages();
                }
                else
                    if (hole3[2] == 13)
                {
                    InventoryManager.instance.RemoveItem(id);
                    bagBalls[id - 1].SetActive(false);
                    hole3[2] = id - 1;
                    updateImages();
                }
                else
                {
                    InventoryManager.instance.RemoveItem(id);
                    bagBalls[id - 1].SetActive(false);
                    InventoryManager.instance.GetItem(hole3[0] + 1);
                    hole3[0] = id - 1;
                    updateImages();
                }
                break;
            case 3://hole 4
                if (hole4[0] == 13)
                {
                    InventoryManager.instance.RemoveItem(id);
                    bagBalls[id - 1].SetActive(false);
                    hole4[0] = id - 1;
                    updateImages();
                }
                else
                    if (hole4[1] == 13)
                {
                    InventoryManager.instance.RemoveItem(id);
                    bagBalls[id - 1].SetActive(false);
                    hole4[1] = id - 1;
                    updateImages();
                }
                else
                    if (hole4[2] == 13)
                {
                    InventoryManager.instance.RemoveItem(id);
                    bagBalls[id - 1].SetActive(false);
                    hole4[2] = id - 1;
                    updateImages();
                }
                else
                {
                    InventoryManager.instance.RemoveItem(id);
                    bagBalls[id - 1].SetActive(false);
                    InventoryManager.instance.GetItem(hole4[0] + 1);
                    hole4[0] = id - 1;
                    updateImages();
                }
                break;
            case 4://hole 5
                if (hole5[0] == 13)
                {
                    InventoryManager.instance.RemoveItem(id);
                    bagBalls[id - 1].SetActive(false);
                    hole5[0] = id - 1;
                    updateImages();
                }
                else
                    if (hole5[1] == 13)
                {
                    InventoryManager.instance.RemoveItem(id);
                    bagBalls[id - 1].SetActive(false);
                    hole5[1] = id - 1;
                    updateImages();
                }
                else
                    if (hole5[2] == 13)
                {
                    InventoryManager.instance.RemoveItem(id);
                    bagBalls[id - 1].SetActive(false);
                    hole5[2] = id - 1;
                    updateImages();
                }
                else
                {
                    InventoryManager.instance.RemoveItem(id);
                    bagBalls[id - 1].SetActive(false);
                    InventoryManager.instance.GetItem(hole5[0] + 1);
                    hole5[0] = id - 1;
                    updateImages();
                }
                break;
            case 5://hole 6
                if (hole6[0] == 13)
                {
                    InventoryManager.instance.RemoveItem(id);
                    bagBalls[id - 1].SetActive(false);
                    hole6[0] = id - 1;
                    updateImages();
                }
                else
                    if (hole6[1] == 13)
                {
                    InventoryManager.instance.RemoveItem(id);
                    bagBalls[id - 1].SetActive(false);
                    hole6[1] = id - 1;
                    updateImages();
                }
                else
                    if (hole6[2] == 13)
                {
                    InventoryManager.instance.RemoveItem(id);
                    bagBalls[id - 1].SetActive(false);
                    hole6[2] = id - 1;
                    updateImages();
                }
                else
                {
                    InventoryManager.instance.RemoveItem(id);
                    bagBalls[id - 1].SetActive(false);
                    InventoryManager.instance.GetItem(hole6[0] + 1);
                    hole6[0] = id - 1;
                    updateImages();
                }
                break;
        }
    }

    public void changeHoleID(int newID)
    {
        holeID = newID;
    }

    public void checkHoles()
    {
        //check if every ball has been put in a hole
        int i;
        bool allused;
        int correct;
        correct = 0;
        allused = true;
        for(i=0;i<12;i++)
            if (InventoryManager.instance.hasItem[i + 1] || menu.collectables[i + 1].activeSelf)
                allused = false;
        if(allused)
        {//all the balls are in a hole somewhere
            Debug.Log("all balls Used");
            //check if right (brute force because .contains/.exists/.find isn't working!)
            if ((hole1[0] == 6 || hole1[1] == 6 || hole1[2] == 6) && (hole1[0] == 0 || hole1[1] == 0 || hole1[2] == 0))
                correct++;
            if ((hole2[0] == 2 || hole2[1] == 2 || hole2[2] == 2) && (hole2[0] == 4 || hole2[1] == 4 || hole2[2] == 4))
                correct++;
            if ((hole3[0] == 3 || hole3[1] == 3 || hole3[2] == 3) && (hole3[0] == 11 || hole3[1] == 11 || hole3[2] == 11))
                correct++;
            if ((hole4[0] == 5 || hole4[1] == 5 || hole4[2] == 5) && (hole4[0] == 9 || hole4[1] == 9 || hole4[2] == 9))
                correct++;
            if ((hole5[0] == 1 || hole5[1] == 1 || hole5[2] == 1) && (hole5[0] == 10 || hole5[1] == 10 || hole5[2] == 10))
                correct++;
            if ((hole6[0] == 8 || hole6[1] == 8 || hole6[2] == 8) && (hole6[0] == 7 || hole6[1] == 7 || hole6[2] == 7))
                correct++;
            Debug.Log(correct+" right!");
            //check if right
            if(correct==6)
            {//got em
                Debug.Log("all balls right!");
                Tutorial.instance.tutorial(9);
            }
            else
            {
                Debug.Log("balls are wrong, reset!");
                Tutorial.instance.tutorial(10);
                for (i = 0; i < 12; i++)
                    menu.collectables[i + 1].SetActive(true);
                for(i=0;i<3;i++)
                {
                    hole1[i] = 13;
                    hole2[i] = 13;
                    hole3[i] = 13;
                    hole4[i] = 13;
                    hole5[i] = 13;
                    hole6[i] = 13;
                }
                updateImages();

            }
        }

    }
    

}
