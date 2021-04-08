using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalVariable : MonoBehaviour
{
    public static GlobalVariable instance;

    public bool canClick;       //if user can click objects, open menus or dialogue  false when in dialogue or menu is open
    public int roomNum;         //room number of user
    public GameObject[] rooms;  //list of rooms
    public bool isGame;         //whether a game exists or if this is a new game
    private int tutorialCount;

    public float doorCooldown; //cooldown for changing rooms

    public int cheeseState; //status of cheese puzzle
    public int poolState;   //status of pool puzzle
    public int discoState;  //status of disco puzzle
    public bool garageOpen; //if the padlock has been opened
    public int garageState; //status of armor puzzle
    public int cultState;   //state of cult interaction
    public bool mazeOpen;   //if maze is open
    public ballScreen ballscreen;//ball screen
    public discoEntry discoDoor;//disco closet

    public SpriteRenderer[] tableCheese;    //cheese sprites on table
    public GameObject[] armour;

   // [HideInInspector]
    public int cardOrigin; //family of chosen card, myths, jokers, etc
   // [HideInInspector]
    public int cardValue;  //value of chosen card, starting at 0 (2-10, jack, queen, king, ace for 13 normal, only 2 jokers) 

    // Start is called before the first frame update
    void Start()
    {  
        canClick = true;
        if (PlayerPrefs.GetInt("isGame") != 1)
        {
            tutorialCount = 0;
            isGame = true;
            Tutorial.instance.tutorial(tutorialCount);
        }
    }

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

    public void yesClick()
    {
        canClick = true;
    }

    public void Update()
    {
        if (doorCooldown > 0)
            doorCooldown -= Time.deltaTime;
    }
}
