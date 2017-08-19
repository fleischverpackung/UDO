using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boot : MonoBehaviour {


    float btnStart;
    float highscore;


    void Start()
    {

        DontDestroyOnLoad(this);
        SceneManager.LoadScene("Splash", LoadSceneMode.Single);
    }


    void Update()
    {

        btnStart = Input.GetAxis("Start");

        if (btnStart >= .8f)
        {
            highscore = 0;
            SceneManager.LoadScene("Dance", LoadSceneMode.Single);

        }

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
