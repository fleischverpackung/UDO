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


        //float wheel = Input.GetAxis("DigiY") * 0.2f;

        if (startGame)
            EventManager.TriggerEvent("sceneDance");

            
        
    }

    public bool GetDanceMode()
    {
        return danceMode;
    }

    /*
    public float GetWheel()
    {
        return wheel;
    }
    */
}

