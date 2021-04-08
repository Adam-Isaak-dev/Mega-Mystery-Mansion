using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatAnim : MonoBehaviour
{
    public bool isCrying;       //true if the rat should be crying - only for chuckles
    public GameObject[] mice;   //list of mice to show when chuckles stops crying
    public Animator anim;
    private float timer;
    private float myTime;
    int i;

    private void Awake()
    {
        myTime = Random.Range(4f, 6f);
    }

    // Update is called once per frame
    void Update()
    {
        if(!isCrying && timer>myTime)
        {
            timer = 0f;
            if (Random.Range(1, 15) == 6)
                anim.SetTrigger("sniff");
            else
                anim.SetTrigger("Blink");
            myTime = Random.Range(4f, 6f);
        }
        if (isCrying && GlobalVariable.instance.cheeseState == 0)
            anim.SetBool("isCrying", true);
        else
        {
            if (isCrying)
                isCrying = false;
            if(anim.GetBool("isCrying"))
                anim.SetBool("isCrying", false);
        }

        timer += Time.deltaTime;
    }

    private void OnMouseDown()
    {
        isCrying = false;
        for (i = 0; i < mice.Length; i++)
            mice[i].SetActive(true);
    }

}
