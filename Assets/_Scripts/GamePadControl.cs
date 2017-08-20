using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class GamePadControl : MonoBehaviour {

    public static GamePadControl Instance { get; private set; } 
    
    public bool startGame = false;
    public bool resurrectUdo = false;
    public bool danceMode = false;
    private string scene;
    private bool udoAlive;
    private bool camMode = false; 
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
            danceMode = true;
        else
            danceMode = false;

        if (Input.GetAxisRaw("TriggerR") != 0)
            camMode = true;        
        else
            camMode = false;

        //Debug.Log(Input.GetAxisRaw("TriggerR"));
        //Debug.Log(Input.GetAxis("TriggerR"));
        //float wheel = Input.GetAxis("DigiY") * 0.2f;

        if (startGame)
            EventManager.TriggerEvent("sceneDance");

            
        
    }

    public bool GetDanceMode()
    {
        return danceMode;
    }

    public bool GetCamMode()
    {
        return camMode;
    }

    /*
    public float GetWheel()
    {
        return wheel;
    }
    */
}

