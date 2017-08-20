using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class GamePadControl : MonoBehaviour {

    //private UnityAction sceneChangeListener;
    private bool start = false;
    private string scene;

    /*
    private void Awake()
    {
        sceneChangeListener = new UnityAction(SceneChange);
    }

    private void OnEnable()
    {
        EventManager.StartListening("sceneChange", sceneChangeListener);
    }

    private void OnDisable()
    {
        EventManager.StopListening("sceneChange", sceneChangeListener);
    }*/


    void Start() {

    }



    void Update() {

        scene = SceneManager.GetActiveScene().name;

        if (Input.GetAxisRaw("Start") != 0 && scene == "Splash")
            start = true;            
        else
            start = false;


        if (start)
            EventManager.TriggerEvent("sceneDance");

    }

    /*
    // GET SCENE NAME JUST ON EVENT
    private void SceneChange()
    {
        scene = SceneManager.GetActiveScene().name;
        Debug.Log("SCENE NAME= " + scene);
    }
    */
}

