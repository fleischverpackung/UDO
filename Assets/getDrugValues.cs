using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class getDrugValues : MonoBehaviour {

    public UdoPlayer player;
    private Text text; 
	// Use this for initialization
	void Start () {
        text = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {

        string tempText = string.Format(" love: {0} \n creativity: {1} \n speed {2}",  player.getLove(), player.getCreativity(), player.getSpeed());
        text.text = tempText;

        
		
	}
}
