using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class Menu : MonoBehaviour
{
    public int levelIndex;    //level index the button loads
    public GameObject escMenu;//esc menu
    public GameObject[] escText;
    public GlobalVariable manager;
    public InventoryManager inventory;
    int counter, counter2;
    public GameObject[] collectables;
    public audioSlider musicSlider;
    public audioSlider soundSlider;
    public AudioClip[] roomMusic; //bg1, dining, sitroom, xylospook, garage, piano, xylobop
    public Image blackScreen;


    private bool exists; //for loading some stuff 
    //load at start
    private void Start()
    {
        if (escMenu != null && PlayerPrefs.GetInt("isGame") == 1)
        {//existing game
            Load();
        }
        else
        {
            if(escMenu!=null)
                GlobalVariable.instance.armour[3].SetActive(false);
        }
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {//in main menu
            if (musicSlider)
            {
                musicSlider.updateFromPref();
                if (musicSlider.mySlider.value >= 0.0001f)
                    musicSlider.onChangeValue();
                else
                {
                    musicSlider.mySlider.value = 0.8f;
                    musicSlider.onChangeValue();
                }
            }
            if(soundSlider)
            {
                soundSlider.updateFromPref();
                if (soundSlider.mySlider.value < 0.0001f)
                    soundSlider.mySlider.value = 0.8f;
            }
        }

    }

    //Saves Game
    public void Save()
    {
        Debug.Log("Saving Game");

        //find room player is in and save that number
        for(counter=0;counter<manager.rooms.Length;counter++)
        {
            if (manager.rooms[counter].activeSelf == true)
                manager.roomNum = counter;
        }
        PlayerPrefs.SetInt("RoomNum", manager.roomNum);

        //save the players inventory (not if each item has been picked up, only if slots are filled)
        //1 is filled 0 is empty
        for (counter=0;counter<30;counter++)
        {
            if (inventory.hasItem[counter])
                PlayerPrefs.SetInt("slot" + counter, 1);
            else
                PlayerPrefs.SetInt("slot" + counter, 0);
        }

        PlayerPrefs.SetInt("isGame", 1);

        //save card of destiny
        PlayerPrefs.SetInt("cardOrigin", GlobalVariable.instance.cardOrigin);
        PlayerPrefs.SetInt("cardValue", GlobalVariable.instance.cardValue);

        //save puzzle progress
        PlayerPrefs.SetInt("cheesePuzzle", GlobalVariable.instance.cheeseState);    //cheese puzzle
        PlayerPrefs.SetInt("poolPuzzle", GlobalVariable.instance.poolState);        //pool puzzle
        PlayerPrefs.SetInt("discoPuzzle", GlobalVariable.instance.discoState);      //disco puzzle
        PlayerPrefs.SetInt("garagePuzzle", GlobalVariable.instance.garageState);    //garage puzzle
        PlayerPrefs.SetInt("outfit", manager.discoDoor.equipedOutfit);  //current outfit
        PlayerPrefs.SetInt("cult", GlobalVariable.instance.cultState);    //garage puzzle
        if (GlobalVariable.instance.mazeOpen)
            PlayerPrefs.SetInt("mazeOpen", 1);
        else
            PlayerPrefs.SetInt("mazeOpen", 0);

        if (ballScreen.instance)
        {//save poolballs
            for(counter=0;counter<3;counter++)
            {
                   PlayerPrefs.SetInt("hole1-" + counter, ballScreen.instance.hole1[counter]);
                   PlayerPrefs.SetInt("hole2-" + counter, ballScreen.instance.hole2[counter]);
                   PlayerPrefs.SetInt("hole3-" + counter, ballScreen.instance.hole3[counter]);
                   PlayerPrefs.SetInt("hole4-" + counter, ballScreen.instance.hole4[counter]);
                   PlayerPrefs.SetInt("hole5-" + counter, ballScreen.instance.hole5[counter]);
                   PlayerPrefs.SetInt("hole6-" + counter, ballScreen.instance.hole6[counter]);
            }
        }

        if (discoEntry.instance)
            PlayerPrefs.SetInt("discoDoor",discoEntry.instance.equipedOutfit);

        //if the garage door is open
        if (GlobalVariable.instance.garageOpen)
            PlayerPrefs.SetInt("padLock", 1);
        else
            PlayerPrefs.SetInt("padLock", 0);

        //save changes
        PlayerPrefs.Save();
    }//save

    //Loads game
    public void Load()
    {
        //load room player was in
        manager.roomNum = PlayerPrefs.GetInt("RoomNum");
        for(counter=0;counter<manager.rooms.Length;counter++)
        {
            if (counter == manager.roomNum)
                manager.rooms[counter].SetActive(true);
            else
                manager.rooms[counter].SetActive(false);
            //music bg1, dining, sitroom, xylospook, garage, piano, xylobop, upstairs
            if(manager.rooms[counter].activeSelf)
            {//change music
                if (counter == 0 || counter == 2 || counter == 3)
                    MusicManager.instance.changeBGM(roomMusic[0]);
                if (counter == 4 || counter == 5 || counter == 6)
                    MusicManager.instance.changeBGM(roomMusic[1]);
                if (counter == 7)
                    MusicManager.instance.changeBGM(roomMusic[2]);
                if (counter == 10)
                    MusicManager.instance.changeBGM(roomMusic[6]);
                if (counter == 1)
                    MusicManager.instance.changeBGM(roomMusic[4]);
                if(counter==14||counter==15)
                    MusicManager.instance.changeBGM(roomMusic[5]);
                if (counter>15)
                    MusicManager.instance.changeBGM(roomMusic[3]);
                if (counter == 8 || counter == 9 || counter == 11 || counter == 12 || counter == 13)
                    MusicManager.instance.changeBGM(roomMusic[7]);
            }
        }
        //load and refresh inventory items
        for (counter=0;counter<30;counter++)
        {
            if (PlayerPrefs.GetInt("slot" + counter) == 1)
                inventory.hasItem[counter] = true;
            else
                inventory.hasItem[counter] = false;
        }
        inventory.refresh();

        //set card
        GlobalVariable.instance.cardOrigin = PlayerPrefs.GetInt("cardOrigin");
        GlobalVariable.instance.cardValue = PlayerPrefs.GetInt("cardValue");

        //set puzzles
        GlobalVariable.instance.cheeseState = PlayerPrefs.GetInt("cheesePuzzle");
        GlobalVariable.instance.poolState = PlayerPrefs.GetInt("poolPuzzle");
        GlobalVariable.instance.discoState = PlayerPrefs.GetInt("discoPuzzle");
        GlobalVariable.instance.garageState = PlayerPrefs.GetInt("garagePuzzle");
        GlobalVariable.instance.cultState = PlayerPrefs.GetInt("cult");
        manager.discoDoor.equipedOutfit = PlayerPrefs.GetInt("outfit");
        if (GlobalVariable.instance.cheeseState == 2)
            for (counter = 0; counter < GlobalVariable.instance.tableCheese.Length; counter++)
                GlobalVariable.instance.tableCheese[counter].enabled = true;

        if (GlobalVariable.instance.garageState == 1)
            GlobalVariable.instance.armour[0].SetActive(true);
        else
            GlobalVariable.instance.armour[0].SetActive(false);
        if (GlobalVariable.instance.garageState == 2)
            GlobalVariable.instance.armour[1].SetActive(true);
        else
            GlobalVariable.instance.armour[1].SetActive(false);
        if (GlobalVariable.instance.garageState == 3)
            GlobalVariable.instance.armour[2].SetActive(true);
        else
            GlobalVariable.instance.armour[2].SetActive(false);
        if (GlobalVariable.instance.garageState == 4)
            GlobalVariable.instance.armour[3].SetActive(true);
        else
            GlobalVariable.instance.armour[3].SetActive(false);

        for (counter = 0; counter < 3; counter++)
        {
            GlobalVariable.instance.ballscreen.hole1[counter] = PlayerPrefs.GetInt("hole1-" + counter);
            GlobalVariable.instance.ballscreen.hole2[counter] = PlayerPrefs.GetInt("hole2-" + counter);
            GlobalVariable.instance.ballscreen.hole3[counter] = PlayerPrefs.GetInt("hole3-" + counter);
            GlobalVariable.instance.ballscreen.hole4[counter] = PlayerPrefs.GetInt("hole4-" + counter);
            GlobalVariable.instance.ballscreen.hole5[counter] = PlayerPrefs.GetInt("hole5-" + counter);
            GlobalVariable.instance.ballscreen.hole6[counter] = PlayerPrefs.GetInt("hole6-" + counter);
        }
        if(GlobalVariable.instance.ballscreen.hole1[0] == GlobalVariable.instance.ballscreen.hole1[1]&& GlobalVariable.instance.ballscreen.hole1[1]!=13)
        {
            Debug.Log("if (going to fill everything with 1's) dont();");
            for (counter = 0; counter < 3; counter++)
            {
                GlobalVariable.instance.ballscreen.hole1[counter] = 13;
                GlobalVariable.instance.ballscreen.hole2[counter] = 13;
                GlobalVariable.instance.ballscreen.hole3[counter] = 13;
                GlobalVariable.instance.ballscreen.hole4[counter] = 13;
                GlobalVariable.instance.ballscreen.hole5[counter] = 13;
                GlobalVariable.instance.ballscreen.hole6[counter] = 13;
            }
        }
        if(GlobalVariable.instance.poolState==2)
        for (counter = 0; counter < Tutorial.instance.poolHoles.Length; counter++)
            Tutorial.instance.poolHoles[counter].SetActive(false);

        if (PlayerPrefs.GetInt("padLock")==1)
            GlobalVariable.instance.garageOpen = true;
        else
            GlobalVariable.instance.garageOpen = false;

        if (manager.discoDoor.equipedOutfit != 0)
            manager.discoDoor.clothes[manager.discoDoor.equipedOutfit - 1].SetActive(false);

        if (PlayerPrefs.GetInt("mazeOpen")==1)
            GlobalVariable.instance.mazeOpen = true;
        else
            GlobalVariable.instance.mazeOpen = false;

        //based on inventory slots, find and destroy associated objects
        for (counter = 0; counter < collectables.Length; counter++)         //if the items aren't destroyed properly, make sure they're in the array
        {                                                                   // (array is set in the editor's manager)
            if (inventory.hasItem[counter])
                collectables[counter].SetActive(false);
            else
                if (counter > 0 && counter < 13) //check for poolballs in holes
            {
                exists = false;
                for(counter2=0;counter2<3;counter2++)
                {
                    if (GlobalVariable.instance.ballscreen.hole1[counter2]!=13|| GlobalVariable.instance.ballscreen.hole2[counter2] != 13 ||
                        GlobalVariable.instance.ballscreen.hole3[counter2] != 13 || GlobalVariable.instance.ballscreen.hole4[counter2] != 13 ||
                        GlobalVariable.instance.ballscreen.hole5[counter2] != 13 || GlobalVariable.instance.ballscreen.hole6[counter2] != 13)
                        exists = true;
                }
                if (exists)
                {
                    Debug.Log("checking a pool hole");
                    for (counter2 = 0; counter2 < 3; counter2++)
                    {
                        if (GlobalVariable.instance.ballscreen.hole1[counter2] == counter - 1)
                            collectables[counter].SetActive(false);
                        else if (GlobalVariable.instance.ballscreen.hole2[counter2] == counter - 1)
                            collectables[counter].SetActive(false);
                        else if (GlobalVariable.instance.ballscreen.hole3[counter2] == counter - 1)
                            collectables[counter].SetActive(false);
                        else if (GlobalVariable.instance.ballscreen.hole4[counter2] == counter - 1)
                            collectables[counter].SetActive(false);
                        else if (GlobalVariable.instance.ballscreen.hole5[counter2] == counter - 1)
                            collectables[counter].SetActive(false);
                        else if (GlobalVariable.instance.ballscreen.hole6[counter2] == counter - 1)
                            collectables[counter].SetActive(false);
                    }
                }
            if (GlobalVariable.instance.poolState == 2)
                collectables[counter].SetActive(false);
            }
                 else
                    collectables[counter].SetActive(true);
        }
    }//load

    //Exits Game
    public void Exit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }//exit

    //deletes all progress
    public void ResetData()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();
    }//delete

    //loads scene of given level index
    public void LoadLevel()
    {
        StartCoroutine(fadeScreen());
    }//levelload

    //show esc menu on button press
    private void Update()
    {
        if (escMenu != null)
        {
            if (Input.GetKeyDown(KeyCode.Escape)&&!blackScreen.gameObject.activeSelf)
            {
                if (escMenu.activeSelf == true)
                {//close esc menu
                    escMenu.SetActive(false);
                    escText[0].SetActive(false);

                    manager.canClick = true;
                    //save volume settings
                    if (musicSlider)
                        musicSlider.saveMyValue();
                    if (soundSlider)
                        soundSlider.saveMyValue();
                }
                else
                {//open esc menu
                    if (manager.canClick&& !blackScreen.gameObject.activeSelf)
                    {
                        escMenu.SetActive(true);
                        manager.canClick = false;
                        cursorController.instance.normalCursor();
                    }
                }
            }
        }
    }

    public void showEsc()
    {
        if (manager.canClick)
        {
            escMenu.SetActive(true);
            manager.canClick = false;
            cursorController.instance.normalCursor();
        }
    }

    public IEnumerator fadeScreen()
    {
        float i;
        blackScreen.gameObject.SetActive(true);
        Cursor.visible = false;
        blackScreen.color = new Color(0f,0f,0f,0f);
        for(i=0;i<100;i++)
        {
            yield return new WaitForSeconds(0.001f);
            blackScreen.color = new Color(0f, 0f, 0f, i/100);
        }
        Cursor.visible = true;
        SceneManager.LoadScene(levelIndex);
    }
}
