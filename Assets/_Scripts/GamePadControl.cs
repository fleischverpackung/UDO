using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using Invector.CharacterController;

public class GamePadControl : MonoBehaviour {

    public static GamePadControl Instance { get; private set; } 
    
    public bool startGame = false;
    public bool resurrectUdo = false;
    public bool pressTriggerL = false;
    private string scene;
    private bool udoAlive;
    private bool pressTriggerR = false;
    private bool pressB = false;
    private bool pressX = false;
    private bool pressY = false;
    //private float wheel;

    private void Awake()
    {
        if (Instance != null)
        {
            DestroyImmediate(gameObject);
            return;
        }
        Instance = this;
        //DontDestroyOnLoad(gameObject);
    }

    void Start() {

    }

    void Update() {

        

        scene = SceneManager.GetActiveScene().name;

        if (UdoPlayer.Instance != null)
            udoAlive = UdoPlayer.Instance.getAlive();

        
        if (Input.GetAxisRaw("Start") != 0 && scene == "Splash")
            startGame = true;          
        else
            startGame = false;
        


        if (Input.GetAxisRaw("TriggerL") != 0 && scene == "Dance")
            pressTriggerL = true;
        else
            pressTriggerL = false;

        if (Input.GetAxisRaw("TriggerR") != 0)
            pressTriggerR = true;        
        else
            pressTriggerR = false;
        
        if (Input.GetAxisRaw("BB") != 0)
            pressB = true;
        else
            pressB = false;

        if (Input.GetAxisRaw("XB") != 0)
            pressX = true;
        else
            pressX = false;

        if (Input.GetAxisRaw("YB") != 0)
            pressY = true;
        else
            pressY = false;


        // Debug.Log(Input.GetAxisRaw("BB"));
        //Debug.Log(Input.GetAxis("TriggerR"));
        //float wheel = Input.GetAxis("DigiY") * 0.2f;

        if (startGame)
            EventManager.TriggerEvent("sceneDance");

            
        
    }

    public bool GetTriggerL()
    {
        return pressTriggerL;
    }

    public bool GetCamMode()
    {
        return pressTriggerR;
    }

    public bool GetB()
    {
        return pressB;
    }
    public bool GetX()
    {
        return pressX;
    }
    public bool GetY()
    {
        return pressY;
    }

    /*
    public float GetWheel()
    {
        return wheel;
    }
    */
}

