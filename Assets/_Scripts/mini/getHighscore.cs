using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class getHighscore : MonoBehaviour {

    

	void Start () {

        this.GetComponent<Text>().text = Boot.Instance.getHighScore().ToString() + " pts";
    }
	

	void Update () {
		
	}
}
