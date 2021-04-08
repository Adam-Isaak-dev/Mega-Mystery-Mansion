using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour
{//for tutorials and cutscenes
    public static Tutorial instance;

    private GlobalVariable manager;

    public DialogueBase tut0dia;
    public Sprite[] cardPics;
    public GameObject cutsceneImage;
    public GameObject cutsceneText;
    public AudioClip BG1;
    public AudioClip spookMusic;

    public DialogueBase ghostIntroDia;
    public DialogueBase ghostWinDia;
    public DialogueBase ghostLoseDia;
    public GameObject[] poolHoles;

    public GameObject cardGet;
    public GameObject blackScreen;
    public GameObject cheesescreen;
    public MoveRoom dinerCall;        //transports player to diner after beating cheese
    public GameObject[] ghostSpeaker; //ghosts that addresses player
    public GameObject smokeBomb;

    public Animator[] skeletons;    //skeleton animators
    public DialogueBase[] skeleDia;

    public DialogueBase[] armourDia;
    public GameObject[] armour;

    public GameObject mazeDoor;

    public DialogueBase[] cultDia;
    public GameObject[] rats;
    public Camera myCamera;
    public AudioClip ratFight;
    public MoveRoom mazeStart;
    public AudioClip ratFightM;

    public GameObject newsButton;

    public Sprite[] endNews;

    public AudioClip sittingMusic;

    private int i;

    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.FindWithTag("manager").GetComponent<GlobalVariable>();
    }

    private void Awake()
    {
        instance = this;
        if(PlayerPrefs.GetInt("isGame")==1)
            StartCoroutine(sceneIn());
    }

    public void tutorial(int index)
    {
        Debug.Log("Started cutscene section id " + index);
        switch(index)
        {
            //================================
            //entry cutscene
            //================================
            case 0://dialog before pick card
                GlobalVariable.instance.canClick = false;
                blackScreen.GetComponent<Image>().color = new Color(0, 0, 0, 1f);
                blackScreen.SetActive(true);
                StartCoroutine(intro());
                break;
            case 1://get card of destiny
                manager.canClick = false;
                blackScreen.SetActive(false);
                cardGet.GetComponent<cardMenu>().randomizeCard();
                cardGet.SetActive(true);
                break;
            case 2://got card
                    blackScreen.GetComponent<Image>().color = new Color(0, 0, 0, 1f);
                    blackScreen.SetActive(true);
                    cardGet.SetActive(false);
                    StartCoroutine(intro2());
                break;

            //===================================
            //cheese puzzle
            //===================================
            case 5://popup cheese screen (for puzzle fail)
                manager.canClick = false;
                cheesescreen.SetActive(true);
                break;
            case 6://beat puzzle
              //  manager.canClick = true;
                dinerCall.remoteCall();
                InventoryManager.instance.GetItem(28);
                break;
            //===================================
            //pool puzzle
            //===================================
            case 7://ghosts appear
                if (GlobalVariable.instance.poolState < 1)
                {
                    GlobalVariable.instance.canClick = false;
                    blackScreen.GetComponent<Image>().color = new Color(0, 0, 0, 0.3f);
                    blackScreen.SetActive(true);
                    GlobalVariable.instance.poolState = 1;
                    StartCoroutine(ghostIntro1(ghostIntroDia));
                }
                break;
            case 8://ghosts vanish
                StartCoroutine(ghostIntro2());
                break;
            case 9://pool win
                InventoryManager.instance.GetItem(27);
                GlobalVariable.instance.canClick = false;
                blackScreen.GetComponent<Image>().color = new Color(0, 0, 0, 0.3f);
                blackScreen.SetActive(true);
                StartCoroutine(ghostIntro1(ghostWinDia));
                break;
            case 10://pool reset
                GlobalVariable.instance.canClick = false;
                blackScreen.GetComponent<Image>().color = new Color(0, 0, 0, 0.3f);
                blackScreen.SetActive(true);
                StartCoroutine(ghostIntro1(ghostLoseDia));
                break;
            //===================================
            //disco puzzle
            //===================================
            case 11://give key
                InventoryManager.instance.GetItem(26);
                break;
            case 12://dance 1
                skeletons[0].SetBool("wrong",true); skeletons[1].SetBool("wrong", false); skeletons[2].SetBool("wrong", false); skeletons[3].SetBool("wrong", false);
                for (i = 0; i < skeletons.Length; i++)
                    skeletons[i].SetTrigger("dance1");
                StartCoroutine(skeledance(0));
                break;
            case 13://dance 2
                skeletons[2].SetBool("wrong", true); skeletons[1].SetBool("wrong", false); skeletons[0].SetBool("wrong", false); skeletons[3].SetBool("wrong", false);
                for (i = 0; i < skeletons.Length; i++)
                    skeletons[i].SetTrigger("dance2");
                StartCoroutine(skeledance(1));
                break;
            case 14://dance 3
                skeletons[3].SetBool("wrong", true); skeletons[1].SetBool("wrong", false); skeletons[2].SetBool("wrong", false); skeletons[0].SetBool("wrong", false);
                for (i = 0; i < skeletons.Length; i++)
                    skeletons[i].SetTrigger("dance3");
                StartCoroutine(skeledance(2));
                break;
            case 15://dance 4
                InventoryManager.instance.GetItem(25);
                skeletons[2].SetBool("wrong", true); skeletons[1].SetBool("wrong", false); skeletons[0].SetBool("wrong", false); skeletons[3].SetBool("wrong", false);
                for (i = 0; i < skeletons.Length; i++)
                    skeletons[i].SetTrigger("dance4");
                StartCoroutine(skeledance(3));
                break;
            //===================================
            //armour puzzle
            //===================================
            case 16://armour takes key
                MusicManager.instance.changeBGM(null);
                GlobalVariable.instance.canClick = false;
                StartCoroutine(armourKeyYoink());
                break;
            case 17://armour turn wood
                MusicManager.instance.changeBGM(null);
                GlobalVariable.instance.canClick = false;
                GlobalVariable.instance.garageState = 2;
                StartCoroutine(armourTransform(0));
                break;
            case 18://armour turn bolt
                MusicManager.instance.changeBGM(null);
                GlobalVariable.instance.canClick = false;
                GlobalVariable.instance.garageState = 3;
                StartCoroutine(armourTransform(1));
                break;
            case 19://armour deafeated
                MusicManager.instance.changeBGM(null);
                GlobalVariable.instance.canClick = false;
                GlobalVariable.instance.garageState = 4;
                StartCoroutine(armourDefeat(0));
                break;
            case 20://heckles leaves
                GlobalVariable.instance.canClick = false;
                InventoryManager.instance.GetItem(24);
                StartCoroutine(armourDefeat(1));
                break;
            //===================================
            //library door
            //===================================
            case 21://library door opens
                if (!GlobalVariable.instance.mazeOpen)
                {
                    GlobalVariable.instance.canClick = false;
                    StartCoroutine(libraryDoorOpen());
                }
                break;

            //===================================
            //Finale
            //===================================
            case 22://heckles mocks u
                GlobalVariable.instance.canClick = false;
                StartCoroutine(ratCultIntro(0));
                break;
            case 23://chuckles arrives
                GlobalVariable.instance.canClick = false;
                StartCoroutine(ratCultIntro(1));
                break;
            case 24://ratfight
                GlobalVariable.instance.canClick = false;
                StartCoroutine(ratCultIntro(2));
                break;
            case 25://ratfight end
                GlobalVariable.instance.canClick = false;
                StartCoroutine(ratCultIntro(3));
                break;
            case 26://rats leave
                GlobalVariable.instance.canClick = false;
                StartCoroutine(ratCultIntro(4));
                break;
            case 27://lose
                mazeStart.remoteCall();
                break;
            case 29://win
                GlobalVariable.instance.canClick = false;
                StartCoroutine(ratCultIntro(6));
                break;
            case 30://return
                rats[0].SetActive(false); rats[1].SetActive(false);
                GlobalVariable.instance.cultState = 1;
                GlobalVariable.instance.canClick = false;
                StartCoroutine(ratCultIntro(5));
                break;
            case 31://newspaper cont
                StartCoroutine(ratCultIntro(7));
                newsButton.SetActive(false);
                break;

        }//switch
    }

    IEnumerator intro()
    {
        int i;
        float alpha;
        Cursor.visible = false;
        MusicManager.instance.changeBGM(null);
        MusicManager.instance.source.pitch = 0.4f;
        yield return new WaitForSeconds(2f);

        cutsceneImage.SetActive(true);
        cutsceneImage.GetComponent<Image>().color = new Color(255, 255, 255, 0f);
        alpha = 0f;
        cutsceneImage.transform.localScale = new Vector2(2f, 1.7f);
        cutsceneImage.GetComponent<Image>().sprite = cardPics[4];
        for (i = 0; i < 100; i++)
        {
            yield return new WaitForSeconds(0.005f);
            alpha += 0.01f;
            cutsceneImage.GetComponent<Image>().color = new Color(255, 255, 255, alpha);
        }
        yield return new WaitForSeconds(3f);
        for (i = 0; i < 100; i++)
        {
            yield return new WaitForSeconds(0.005f);
            alpha -= 0.01f;
            cutsceneImage.GetComponent<Image>().color = new Color(255, 255, 255, alpha);
        }

        yield return new WaitForSeconds(1f);
        MusicManager.instance.changeBGM(spookMusic);
        cutsceneImage.transform.localScale = new Vector2(1f, 1f);
        cutsceneImage.GetComponent<Image>().sprite = cardPics[0];
        for(i=0;i<100;i++)
        {
            yield return new WaitForSeconds(0.005f);
            alpha += 0.01f;
            cutsceneImage.GetComponent<Image>().color = new Color(255, 255, 255, alpha);
        }
        yield return new WaitForSeconds(0.6f);
        for (i = 0; i < 100; i++)
        {
            yield return new WaitForSeconds(0.005f);
            alpha -= 0.01f;
            cutsceneImage.GetComponent<Image>().color = new Color(255, 255, 255, alpha);
        }
        cutsceneImage.GetComponent<Image>().sprite = cardPics[1];
        alpha = 0f;
        for (i = 0; i < 100; i++)
        {
            yield return new WaitForSeconds(0.005f);
            alpha += 0.01f;
            cutsceneImage.GetComponent<Image>().color = new Color(255, 255, 255, alpha);
        }
        yield return new WaitForSeconds(0.6f);
        for (i = 0; i < 100; i++)
        {
            yield return new WaitForSeconds(0.005f);
            alpha -= 0.01f;
            cutsceneImage.GetComponent<Image>().color = new Color(255, 255, 255, alpha);
        }
        cutsceneImage.GetComponent<Image>().sprite = cardPics[2];
        alpha = 0f;
        for (i = 0; i < 100; i++)
        {
            yield return new WaitForSeconds(0.005f);
            alpha += 0.01f;
            cutsceneImage.GetComponent<Image>().color = new Color(255, 255, 255, alpha);
        }
        yield return new WaitForSeconds(0.6f);
        for (i = 0; i < 100; i++)
        {
            yield return new WaitForSeconds(0.005f);
            alpha -= 0.01f;
            cutsceneImage.GetComponent<Image>().color = new Color(255, 255, 255, alpha);
        }
        cutsceneImage.GetComponent<Image>().sprite = cardPics[3];
        alpha = 0f;
        for (i = 0; i < 100; i++)
        {
            yield return new WaitForSeconds(0.005f);
            alpha += 0.01f;
            cutsceneImage.GetComponent<Image>().color = new Color(255, 255, 255, alpha);
        }
        yield return new WaitForSeconds(0.6f);
        for (i = 0; i < 100; i++)
        {
            yield return new WaitForSeconds(0.005f);
            alpha -= 0.01f;
            cutsceneImage.GetComponent<Image>().color = new Color(255, 255, 255, alpha);
        }

        yield return new WaitForSeconds(1f);
        Cursor.visible = true;
        cutsceneImage.SetActive(false);
        DialogueManager.instance.EnqueueDialogue(tut0dia);
    }

    IEnumerator intro2()
    {
        int i; float alpha;
        blackScreen.SetActive(true);
        blackScreen.GetComponent<Image>().color = new Color(0, 0, 0, 1f);
        MusicManager.instance.changeBGM(null);
        Cursor.visible = false;
        yield return new WaitForSeconds(0.5f);
        AudioManager.instance.PlayClip(AudioManager.instance.woosh);
        yield return new WaitForSeconds(0.4f);
        alpha = 1;
        for (i = 0; i < 100; i++)
        {
            yield return new WaitForSeconds(0.01f);
            alpha -= 0.01f;
            blackScreen.GetComponent<Image>().color = new Color(0, 0, 0, alpha);
        }
        yield return new WaitForSeconds(0.1f);
        Cursor.visible = true;
        GlobalVariable.instance.canClick = true;
        blackScreen.SetActive(false);
        MusicManager.instance.source.pitch = 1f;
        MusicManager.instance.changeBGM(BG1);
    }

        IEnumerator ghostIntro1(DialogueBase dia)
    {
        MusicManager.instance.changeBGM(null);
        for (i = 0; i < 3; i++)
        {
            GlobalVariable.instance.ballscreen.hole1[i] = 13;
            GlobalVariable.instance.ballscreen.hole2[i] = 13;
            GlobalVariable.instance.ballscreen.hole3[i] = 13;
            GlobalVariable.instance.ballscreen.hole4[i] = 13;
            GlobalVariable.instance.ballscreen.hole5[i] = 13;
            GlobalVariable.instance.ballscreen.hole6[i] = 13;
        }
        yield return new WaitForSeconds(0.2f);
        AudioManager.instance.PlayClip(AudioManager.instance.horror);
        yield return new WaitForSeconds(0.5f);
        for (i = 0; i < ghostSpeaker.Length; i++)
        {
            ghostSpeaker[i].SetActive(true);
            Instantiate(smokeBomb, ghostSpeaker[i].transform);
        }
        yield return new WaitForSeconds(1.5f);
        blackScreen.SetActive(false);
        DialogueManager.instance.EnqueueDialogue(dia);
        if (dia == ghostWinDia)
        {
            GlobalVariable.instance.poolState = 2;
            for (i = 0; i < poolHoles.Length; i++)
                poolHoles[i].SetActive(false);
        }
    }

    IEnumerator ghostIntro2()
    {
        blackScreen.SetActive(true);
        GlobalVariable.instance.canClick = false;
        yield return new WaitForSeconds(0.3f);
        for (i = 0; i < ghostSpeaker.Length; i++)
            Instantiate(smokeBomb, ghostSpeaker[i].transform);
        yield return new WaitForSeconds(0.8f);
        blackScreen.GetComponent<Image>().color = new Color(255, 255, 255, 1f);
        if(GlobalVariable.instance.poolState!=2)
            for (i = 0; i < ghostSpeaker.Length; i++)
                ghostSpeaker[i].SetActive(false);
        yield return new WaitForSeconds(1.5f);
        MusicManager.instance.changeBGM(sittingMusic);
        blackScreen.GetComponent<Image>().color = new Color(0, 0, 0, 1f);
        blackScreen.SetActive(false);
        manager.canClick = true;
    }

    IEnumerator skeledance(int id)
    {
        blackScreen.SetActive(true);
        blackScreen.GetComponent<Image>().color = new Color(255, 0, 0, 0.35f);
        GlobalVariable.instance.canClick = false;
        yield return new WaitForSeconds(1f);
        blackScreen.GetComponent<Image>().color = new Color(0, 255, 0, 0.35f);
        yield return new WaitForSeconds(1f);
        blackScreen.GetComponent<Image>().color = new Color(0, 0, 255, 0.35f);
        yield return new WaitForSeconds(1f);
        blackScreen.GetComponent<Image>().color = new Color(0, 255, 255, 0.35f);
        yield return new WaitForSeconds(1f);
        blackScreen.GetComponent<Image>().color = new Color(255, 0, 0, 0.35f);
        yield return new WaitForSeconds(1f);
        blackScreen.GetComponent<Image>().color = new Color(0, 50, 255, 0.35f);
        yield return new WaitForSeconds(1f);
        blackScreen.GetComponent<Image>().color = new Color(50, 250, 50, 0.35f);
        yield return new WaitForSeconds(1f);
        blackScreen.GetComponent<Image>().color = new Color(0, 0, 0, 1f);
        blackScreen.SetActive(false);
        DialogueManager.instance.EnqueueDialogue(skeleDia[id]);
    }

    IEnumerator armourKeyYoink()
    {
        yield return new WaitForSeconds(0.1f);
        AudioManager.instance.PlayClip(AudioManager.instance.glassBreak);
        blackScreen.SetActive(true);
        yield return new WaitForSeconds(0.8f);
        Cursor.visible = false;
        blackScreen.GetComponent<Image>().color = new Color(0, 0, 0, 1f);
        GlobalVariable.instance.garageState = 1;
        AudioManager.instance.PlayClip(AudioManager.instance.metalWalk);
        yield return new WaitForSeconds(3f);
        armour[0].SetActive(true);
        yield return new WaitForSeconds(3.5f);
        AudioManager.instance.PlayClip(AudioManager.instance.pickup);
        yield return new WaitForSeconds(1f);
        blackScreen.SetActive(false);
        armour[0].GetComponent<Animator>().SetTrigger("laugh");
        AudioManager.instance.PlayClip(AudioManager.instance.evilLaugh);
        yield return new WaitForSeconds(4f);
        Cursor.visible = true;
        DialogueManager.instance.EnqueueDialogue(armourDia[0]);
    }

    IEnumerator armourTransform(int id)
    {
        Cursor.visible = false;
        yield return new WaitForSeconds(0.1f);
        armour[id].GetComponent<Animator>().SetTrigger("break");
        AudioManager.instance.PlayClip(AudioManager.instance.machineStruggle);
        yield return new WaitForSeconds(2f);
        armour[id].GetComponent<Animator>().SetTrigger("break");
        yield return new WaitForSeconds(2f);
        armour[id].GetComponent<Animator>().SetTrigger("break");
        blackScreen.SetActive(true);
        blackScreen.GetComponent<Image>().color = new Color(0, 0, 0, 1f);
        yield return new WaitForSeconds(2f);
        AudioManager.instance.PlayClip(AudioManager.instance.glassBreak);
        yield return new WaitForSeconds(1f);
        AudioManager.instance.PlayClip(AudioManager.instance.glassBreak);
        yield return new WaitForSeconds(1f);
        if (id == 0)
        { armour[0].SetActive(false); armour[1].SetActive(true); }
        else
        { armour[1].SetActive(false);armour[2].SetActive(true); }
        AudioManager.instance.PlayClip(AudioManager.instance.glassBreak);
        yield return new WaitForSeconds(2f);
        blackScreen.SetActive(false);
        armour[id+1].GetComponent<Animator>().SetTrigger("laugh");
        AudioManager.instance.PlayClip(AudioManager.instance.evilLaugh);
        yield return new WaitForSeconds(4f);
        Cursor.visible = true;
        DialogueManager.instance.EnqueueDialogue(armourDia[id+1]);
    }

    IEnumerator armourDefeat(int part)
    {
        if (part == 0)//heckles appears
        {
            Cursor.visible = false;
            yield return new WaitForSeconds(0.1f);
            armour[2].GetComponent<Animator>().SetTrigger("break");
            AudioManager.instance.PlayClip(AudioManager.instance.machineStruggle);
            yield return new WaitForSeconds(2f);
            armour[2].GetComponent<Animator>().SetTrigger("break");
            yield return new WaitForSeconds(2f);
            armour[2].GetComponent<Animator>().SetTrigger("break");
            blackScreen.SetActive(true);
            blackScreen.GetComponent<Image>().color = new Color(0, 0, 0, 1f);
            yield return new WaitForSeconds(2f);
            AudioManager.instance.PlayClip(AudioManager.instance.glassBreak);
            yield return new WaitForSeconds(1f);
            AudioManager.instance.PlayClip(AudioManager.instance.glassBreak);
            yield return new WaitForSeconds(1f);
            armour[3].SetActive(true);
            armour[4].SetActive(true);
            armour[2].SetActive(false);
            armour[3].GetComponent<Animator>().SetTrigger("fall");
            AudioManager.instance.PlayClip(AudioManager.instance.glassBreak);
            yield return new WaitForSeconds(2f);
            blackScreen.SetActive(false);
            yield return new WaitForSeconds(2f);
            armour[3].GetComponent<Animator>().SetTrigger("stand");
            yield return new WaitForSeconds(1f);
            Cursor.visible = true;
            DialogueManager.instance.EnqueueDialogue(armourDia[3]);
        }
        else//heckles leaves
        {
            Cursor.visible = false;
            yield return new WaitForSeconds(0.2f);
            blackScreen.SetActive(true);
            blackScreen.GetComponent<Image>().color = new Color(0, 0, 0, 1f);
            yield return new WaitForSeconds(1f);
            AudioManager.instance.PlayClip(AudioManager.instance.glassBreak);
            armour[3].SetActive(false);
            yield return new WaitForSeconds(1f);
            Cursor.visible = true;
            GlobalVariable.instance.canClick = true;
            Cursor.visible = true;
            blackScreen.SetActive(false);
        }
    }

    IEnumerator libraryDoorOpen()
    {
        mazeDoor.GetComponent<Animator>().SetTrigger("open");
        AudioManager.instance.PlayClip(AudioManager.instance.shelfMove);
        yield return new WaitForSeconds(2f);
        GlobalVariable.instance.mazeOpen = true;
        GlobalVariable.instance.canClick = true;
    }

    IEnumerator ratCultIntro(int id)
    {
        float i;
        GlobalVariable.instance.cultState = 1;
        if (id == 0)
        {
            rats[0].SetActive(true);rats[1].SetActive(false);
            MusicManager.instance.changeBGM(null);
            yield return new WaitForSeconds(2f);
            DialogueManager.instance.EnqueueDialogue(cultDia[id]);
        }
        if(id==1)
        {
            yield return new WaitForSeconds(0.3f);
            blackScreen.SetActive(true);
            blackScreen.GetComponent<Image>().color = new Color(255, 255, 255, 1f);
            AudioManager.instance.PlayClip(AudioManager.instance.woosh);
            rats[0].SetActive(true); rats[1].SetActive(true);
            yield return new WaitForSeconds(1f);
            blackScreen.SetActive(false);
            yield return new WaitForSeconds(0.8f);
            for (i = 0; i <= 2.5; i += 0.01f)
            {
                myCamera.orthographicSize = 5 - i;
                myCamera.gameObject.transform.position = new Vector3(0, -i,-11);
                yield return new WaitForSeconds(0.01f);
            }
            yield return new WaitForSeconds(1f);
            DialogueManager.instance.EnqueueDialogue(cultDia[id]);
        }
        if(id==2)
        {
            yield return new WaitForSeconds(0.2f);
            blackScreen.SetActive(true);
            blackScreen.GetComponent<Image>().color = new Color(255, 255, 255, 1f);
            AudioManager.instance.PlayClip(AudioManager.instance.woosh);
            rats[0].GetComponent<Animator>().SetTrigger("fight");
            yield return new WaitForSeconds(0.03f);
            rats[1].GetComponent<Animator>().SetTrigger("fight");
            rats[0].transform.position = new Vector2(-0.4f, -2.6f);
            rats[1].transform.position = new Vector2(0.4f, -2.6f);
            yield return new WaitForSeconds(0.2f);
            blackScreen.SetActive(false);
            AudioManager.instance.PlayClip(ratFight);
            yield return new WaitForSeconds(3f);
            DialogueManager.instance.EnqueueDialogue(cultDia[id]);
        }
        if(id==3)
        {
            yield return new WaitForSeconds(0.2f);
            blackScreen.SetActive(true);
            blackScreen.GetComponent<Image>().color = new Color(255, 255, 255, 1f);
            AudioManager.instance.PlayClip(AudioManager.instance.woosh);
            rats[0].GetComponent<Animator>().SetTrigger("endFight");
            yield return new WaitForSeconds(0.03f);
            rats[1].GetComponent<Animator>().SetTrigger("endFight");
            rats[0].transform.position = new Vector2(-1f, -2.6f);
            rats[1].transform.position = new Vector2(1f, -2.6f);
            yield return new WaitForSeconds(0.07f);
            blackScreen.SetActive(false);
            yield return new WaitForSeconds(1f);
            DialogueManager.instance.EnqueueDialogue(cultDia[id]);
        }
        if(id==4)
        {
            yield return new WaitForSeconds(1f);
            blackScreen.SetActive(true);
            blackScreen.GetComponent<Image>().color = new Color(255, 255, 255, 1f);
            rats[0].SetActive(false);rats[1].SetActive(false);
            myCamera.orthographicSize = 5;
            myCamera.gameObject.transform.position = new Vector3(0, 0, -11);
            AudioManager.instance.PlayClip(AudioManager.instance.woosh);
            yield return new WaitForSeconds(0.6f);
            blackScreen.SetActive(false);
            yield return new WaitForSeconds(0.5f);
            DialogueManager.instance.EnqueueDialogue(cultDia[id]);
        }
        if (id == 5)
        {
            yield return new WaitForSeconds(1f);
            DialogueManager.instance.EnqueueDialogue(cultDia[id]);
        }
        if (id == 6)
        {
            float alpha;
            yield return new WaitForSeconds(0.2f);
            blackScreen.SetActive(true);
            MusicManager.instance.changeBGM(null);
            blackScreen.GetComponent<Image>().color = new Color(0, 0, 0, 0f);
            for (i = 0; i < 100; i++)
            {
                yield return new WaitForSeconds(0.01f);
                blackScreen.GetComponent<Image>().color = new Color(0, 0, 0, i / 100f);
            }
            yield return new WaitForSeconds(0.5f);

            cutsceneImage.SetActive(true);
            cutsceneImage.GetComponent<Image>().color = new Color(255, 255, 255, 0f);
            alpha = 0f;
            cutsceneImage.transform.localScale = new Vector2(2f, 1.7f);
            cutsceneImage.GetComponent<Image>().sprite = endNews[GlobalVariable.instance.discoDoor.equipedOutfit];
            for (i = 0; i < 100; i++)
            {
                yield return new WaitForSeconds(0.005f);
                alpha += 0.01f;
                cutsceneImage.GetComponent<Image>().color = new Color(255, 255, 255, alpha);
            }
            yield return new WaitForSeconds(0.6f);
            newsButton.SetActive(true);
        }
        if(id==7)
        {
            float alpha = 1;
            yield return new WaitForSeconds(0.3f);
            for (i = 0; i < 100; i++)
            {
                yield return new WaitForSeconds(0.005f);
                alpha -= 0.01f;
                cutsceneImage.GetComponent<Image>().color = new Color(255, 255, 255, alpha);
            }
            yield return new WaitForSeconds(0.2f);
            SceneManager.LoadScene(2);
        }
    }

    IEnumerator sceneIn()
    {
        blackScreen.SetActive(true);
        blackScreen.GetComponent<Image>().color = new Color(0, 0, 0, 0f);
        Cursor.visible = false;
        for (i = 100; i > 0; i--)
        {
            yield return new WaitForSeconds(0.0002f);
            blackScreen.GetComponent<Image>().color = new Color(0, 0, 0, i / 100f);
        }
        blackScreen.SetActive(false);
        Cursor.visible = true;
    }
}
