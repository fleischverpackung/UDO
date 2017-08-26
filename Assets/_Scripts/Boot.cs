using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boot : MonoBehaviour {

    public static Boot Instance { get; private set; }

    private float btnStart;
    private int highscore;
    private string scene;



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
        SceneManager.LoadScene("Splash");
    }


    void Update()
    {
        scene = SceneManager.GetActiveScene().name;

        if (Input.GetAxisRaw("Start") != 0 && scene == "Splash")
            SceneManager.LoadScene("Dance");

    }

    public void setHighscore(int x)
    {
        highscore = x;
    }
    public int getHighScore()
    {
        return highscore;
    }
}
