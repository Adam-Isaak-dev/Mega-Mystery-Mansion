using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class discoEntry : MonoBehaviour
{
    public static discoEntry instance;

    public GameObject[] clothes;
    public GameObject closed, open;
    public int equipedOutfit;   //0 is no outfit

    int i;

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

    public void pickThisOutfit(int id)
    {
        clothes[id].SetActive(false);
        for (i = 0; i < clothes.Length; i++)
            if (i != id)
                clothes[i].SetActive(true);
        equipedOutfit = id + 1;
    }
}
