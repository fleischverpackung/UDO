using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour {

    public static Timer Instance { get; private set; }

    private int timerMax = 30;
    public float danceTime = 0;
    public float killLevel;
    public float killCounter;
    private bool isDancing = false;
    private float timerInterval = 1;
    public float score = 0;
    public bool alive = true;

    private void Awake()
    {
        if (Instance != null)
        {
            DestroyImmediate(gameObject);
            return;
        }
        Instance = this;
    }

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
                Debug.Log("highscore set");
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

    public float GetHighscore()
    {
        return score;
    }

    public float GetTimer()
    {
        return timerMax;
    }

}
