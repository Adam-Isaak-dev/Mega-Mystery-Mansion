using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Event", menuName = "Events")]
public class EventBehaviour : ScriptableObject
{
    public void TestEvent()
    {
        //basically insert what happens i guess
        Debug.Log("test event 1");
    }

    public void TestEvent2()
    {
        //basically insert what happens i guess
        Debug.Log("test event 2");
    }
}
