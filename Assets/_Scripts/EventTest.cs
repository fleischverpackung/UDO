using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class EventTest : MonoBehaviour {

    private UnityAction someListener;
    private UnityAction someOtherListener;

    private void Awake()
    {
        someListener = new UnityAction(SomeFunction);
        someOtherListener = new UnityAction(FUCKYOUTOO);
    }

    // listener muss disables werden, weil objekt kann gelöscht sein, aber listener verbleibt.
    // wird dann nicht gecleaned up. = memory leak.
    // deswegen nicht in Awake() oder Destroy()
    private void OnEnable()
    {
        EventManager.StartListening("test", someListener);
        EventManager.StartListening("test", someOtherListener);
    }

    private void OnDisable()
    {
        EventManager.StopListening("test", someListener);
    }

    void SomeFunction()
    {
        Debug.Log("FUCKOYU");
        
    }

    void FUCKYOUTOO()
    {
        Debug.Log("FU2");
    }
}
