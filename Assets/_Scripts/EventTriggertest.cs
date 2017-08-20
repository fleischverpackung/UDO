using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventTriggertest : MonoBehaviour {


    private void Update()
    {
        if(Input.GetKeyDown("q"))
        {
            EventManager.TriggerEvent("test");
        }
    }
}
