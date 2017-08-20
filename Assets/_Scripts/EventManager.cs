using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventManager : MonoBehaviour {

    private Dictionary<string, UnityEvent> eventDictionary;
    private static EventManager manager;


    // warum instance? irgendwas wie singleton..
    public static EventManager instance
    {
        get
        {
            if (!manager)
            {
                //wenn der manager nicht existiert suchen wir ihn und weisen ihn zu
                manager = FindObjectOfType(typeof(EventManager)) as EventManager;
                //wenn er nicht gefunden wird throw error
                if (!manager)
                    Debug.LogError("There needs to be one active Eventmanager script on a Gameobject in your scene");
                else
                {
                    manager.Init();
                }
            }
            return manager;
        }
    }

    void Init()
    {
        if (eventDictionary == null)
        {
            eventDictionary = new Dictionary<string, UnityEvent>();
        }
    }

    //unity action ist ein pointer zur function
    public static void StartListening(string eventName, UnityAction listener)
    {
        
        UnityEvent thisEvent = null;

        //testen ob keyvaluepair existiert bevor etwas in die collection eingefügt wird
        //trygetvalue similar to conatins key but faster and more safer
        if (instance.eventDictionary.TryGetValue (eventName, out thisEvent))
        {
            thisEvent.AddListener(listener);
        }
        else
        {
            thisEvent = new UnityEvent();
            thisEvent.AddListener(listener);
            instance.eventDictionary.Add(eventName, thisEvent);            
        }
    }

    public static void StopListening(string eventName, UnityAction listener)
    {
        // return falls manager zu dem zeitpunkt nicht mehr existiert
        if (manager == null) return;
        UnityEvent thisEvent = null;
        if (instance.eventDictionary.TryGetValue (eventName, out thisEvent))
        {
            thisEvent.RemoveListener(listener);
        }
    }

    public static void TriggerEvent(string eventName)
    {
        UnityEvent thisEvent = null;
        if (instance.eventDictionary.TryGetValue(eventName, out thisEvent))
        {
            thisEvent.Invoke();
        }
    }


    
}
