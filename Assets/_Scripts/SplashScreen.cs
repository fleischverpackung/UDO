using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SplashScreen : MonoBehaviour {

    private Boot bootscript;
    float btnStart;
    float highscore;
    public Text hs;
    public LB_Leaderboard _lb;

    private void Awake()
    {
        //_lb.SetUpScores();

    }

    void Start()
    {
        bootscript = GameObject.Find("BOOT").GetComponent<Boot>();        
        hs.text = Mathf.Round(bootscript.getHighScore()).ToString();

        

        
        //PlayerPrefs.SetInt("finalScore", (int)Mathf.Round(bootscript.getHighScore()));
        //_lb.DidGetHighScore(Mathf.Round(bootscript.getHighScore()));
        //SceneManager.LoadScene("ShowLeaderboard");
    }
            
	

	void Update () {

        
       
    }
    
}
