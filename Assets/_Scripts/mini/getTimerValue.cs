using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class getTimerValue : MonoBehaviour {

    private string minutes;
    private string seconds;
    private float timer;
    public Text timerIngame;

    public void Awake()
    {
        timerIngame = GetComponent<Text>();
    }


    void Update()
    {
        // FORMAT MINUTES AND SECONDS
        /*
        timer = UdoPlayer.Instance.GetTimer();
        minutes = Mathf.Floor(timer / 60).ToString("0");
        seconds = (timer % 60).ToString("00");
        timerIngame.text = minutes + ":" + seconds;
        */

        timerIngame.text = string.Format(UdoPlayer.Instance.GetTimer().ToString());
    }
}
