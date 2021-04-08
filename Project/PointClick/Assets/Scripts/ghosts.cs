using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ghosts : MonoBehaviour
{
    public GameObject[] spectres;
    private int i;

    // Update is called once per frame
    void Update()
    {
        if (!spectres[0].activeSelf && GlobalVariable.instance.poolState == 2)
            for (i = 0; i < spectres.Length; i++)
                spectres[i].SetActive(true);
        if (GlobalVariable.instance.poolState == 0)
        {
            Tutorial.instance.tutorial(7);
           // GlobalVariable.instance.poolState = 1;
        }
    }
}
