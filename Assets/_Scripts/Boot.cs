using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boot : MonoBehaviour {

    public static Boot Instance { get; private set; }

    private float btnStart;
    private float highscore;



    private void Awake()
    {
        if (Instance != null)
        {
            DestroyImmediate(gameObject);
            return;
        }
        Instance = this;
    }


    void Start()
    {
        DontDestroyOnLoad(this);
        EventManager.TriggerEvent("sceneSplash");
        //SceneManager.LoadScene("Splash", LoadSceneMode.Single);
    }


    void Update()
    {
    
    }

    public void setHighscore(float x)
    {
        highscore = x;
    }
    public float getHighScore()
    {
        return highscore;
    }
}
