using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager instance;

    public GameObject InventoryUI;
    public GameObject []slots;
    private GlobalVariable manager;
    public Color disabled;
    public bool[] hasItem;
    private int i;

    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.FindWithTag("manager").GetComponent<GlobalVariable>();
        for (i = 0; i < 30; i++)
        {
            if (hasItem[i] == true)
                slots[i].GetComponent<Image>().color = new Color(100f, 100f, 100f, 225f);
            else
                slots[i].GetComponent<Image>().color = disabled;
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

    // Update is called once per frame
    void Update()
    {
        if (manager.canClick && InventoryUI.activeSelf == false)
            InventoryUI.SetActive(true);
        else
            if (manager.canClick == false && InventoryUI.activeSelf == true)
            InventoryUI.SetActive(false);
    }

    public void GetItem(int itemID)
    {
        Debug.Log("Obtained item with ID " + itemID);
        hasItem[itemID] = true;
        refresh();
    }

    public void RemoveItem(int itemID)
    {
        Debug.Log("Removed item with ID " + itemID);
        hasItem[itemID] = false;
        refresh();
    }

    public void refresh()
    {
        //update the inventory's visuals
        for (i = 0; i < 30; i++)
        {
            if (hasItem[i] == true)
                slots[i].GetComponent<Image>().color = new Color(100f, 100f, 100f, 225f);
            else
                slots[i].GetComponent<Image>().color = disabled;
        }
    }
}
