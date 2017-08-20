using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class getTimerValue : MonoBehaviour {

    private Timer timer;
    private Text text;
    private 


    void Start()
    {
        text = GetComponent<Text>();
        timer = GameObject.Find("TIMER").GetComponent<Timer>();
    }


    void Update()
    {


        string tempText = string.Format(timer.GetTimer().ToString());
        text.text = tempText;



    }
}
