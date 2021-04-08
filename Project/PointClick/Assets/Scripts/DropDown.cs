using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropDown : MonoBehaviour
{
    public Dropdown dropdown;
    public Image myImage;

    private void Awake()
    {
        imageUpdate();
    }
    public void imageUpdate()
    {
        if (dropdown.value != 0)
        {
            myImage.enabled = true;
            myImage.sprite = dropdown.captionImage.sprite;
        }
        else
        {
            myImage.enabled = false;
        }
    }
}
