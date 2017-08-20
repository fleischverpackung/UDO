using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class SceneControl : MonoBehaviour {


    private UnityAction listenerSplash;
    private UnityAction listenerDance;

    

    private void Awake()
    {

        listenerSplash = new UnityAction(LoadSplash);
        listenerDance = new UnityAction(LoadDance);
    }

    private void OnEnable()
    {
        EventManager.StartListening("sceneSplash", listenerSplash);
        EventManager.StartListening("sceneDance", listenerDance);
    }

    private void OnDisable()
    {
        EventManager.StopListening("sceneSplash", listenerSplash);
        EventManager.StopListening("sceneDance", listenerDance);
    }

    private void LoadSplash()
    {
        SceneManager.LoadScene("Splash", LoadSceneMode.Single);
<<<<<<< HEAD
        //UdoPlayer.Instance.Destroy();
=======
>>>>>>> parent of 9c7dcb4... udoScriptAuslagern
        //EventManager.TriggerEvent("sceneChange");
    }

    private void LoadDance()
    {
        SceneManager.LoadScene("Dance", LoadSceneMode.Single);
        //EventManager.TriggerEvent("sceneChange");
    }
}
