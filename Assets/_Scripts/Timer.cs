using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour {

    private int timerMax = 30;
    public float danceTime = 0;
    public float killLevel;
    public float killCounter;
    private bool isDancing = false;
    private float timerInterval = 1;
    private xxx control;
    public float score = 0;
    public bool alive = true;
    UdoPlayer udo;
    private Boot boot;
    private GameObject gui;

    // Use this for initialization
    void Start () {
        StartCoroutine(Countdown());
        control = GameObject.Find("DISPENSER").GetComponent<xxx>();
        udo = GameObject.Find("UDO").GetComponent<UdoPlayer>();
        boot = GameObject.Find("BOOT").GetComponent<Boot>();
        gui = GameObject.Find("Death");
    }
	
	// Update is called once per frame
	void Update () {

        udo.redundandHighscore = score;


        if (udo != null)
        {
            isDancing = control.GetDanceStatus();
            killLevel = udo.getKillLevel();
            alive = udo.getAlive();

            if (isDancing)
                danceTime += Time.deltaTime;

            killCounter += killLevel;

            score = (danceTime * killLevel) ;

            //if (!alive)
               // LoadSplash();
                
        }
        
            
    }

    IEnumerator Countdown()
    {
        while(true)
        {
            yield return new WaitForSeconds(timerInterval);
            timerMax -= 1;
            if (timerMax <= 0)
                LoadSplash();
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



    public void LoadSplash()
    {
        boot.setHighscore(score);
        EventManager.TriggerEvent("sceneSplash");
        //SceneManager.LoadScene("Splash", LoadSceneMode.Single);
    }


    public int GetTimer()
    {
        return timerMax;
    }

}
