using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class getHighscore : MonoBehaviour {

    
	// Use this for initialization
	void Start () {

        this.GetComponent<Text>().text = Mathf.Round(Boot.Instance.getHighScore()).ToString() + " pts";


    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
