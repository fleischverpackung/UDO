using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class getDrugValues : MonoBehaviour {

    public UdoPlayer player;
    private Text text; 


	void Start () {
        text = GetComponent<Text>();
        player = GameObject.Find("UDO").GetComponent<UdoPlayer>();
	}
	

	void Update () {

        //string tempText = string.Format(" LOVE: {0} \n SANITY: {1} \n HEALTH {2}", Mathf.Round(player.getLove()), Mathf.Round(player.getCreativity()), Mathf.Round(player.getSpeed()));

        string tempText = string.Format(" LOVE: {0} \n SANITY: {1} \n HEALTH {2}", player.getLove(), player.getSanity(), player.getSpeed());
        text.text = tempText;

        
		
	}
}
