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


    void Start()
    {
        bootscript = GameObject.Find("BOOT").GetComponent<Boot>();        
        hs.text = "HIGHSCORE: " + Mathf.Round(bootscript.getHighScore()).ToString() +" PUNKTE";
    }
            
	

	void Update () {

        
       
    }
    
}
