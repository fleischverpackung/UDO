using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour {

    private int timerMax = 30;
    public float danceTime = 0;
    public float killLevel;
    public float killCounter;
    private bool isDancing = false;
    private float timerInterval = 1;
    public float score = 0;
    public bool alive = true;


    void Start ()
    {
        StartCoroutine(Countdown());
    }
	

	void Update ()
    {
        isDancing = GamePadControl.Instance.GetDanceMode();               
        killLevel = UdoPlayer.Instance.getKillLevel();
        alive = UdoPlayer.Instance.getAlive();

        if (isDancing)
            danceTime += Time.deltaTime;

        killCounter += killLevel;
        score = (danceTime * killLevel);  
    }

    IEnumerator Countdown()
    {
        while(true)
        {
            yield return new WaitForSeconds(timerInterval);
            timerMax -= 1;
            if (timerMax <= 0)
            {
                Boot.Instance.setHighscore(score);
                EventManager.TriggerEvent("sceneSplash");
            }                
        }        
    }

    IEnumerator DanceTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(timerInterval);
            danceTime += 1;
        }
    }

    public int GetTimer()
    {
        return timerMax;
    }

}
