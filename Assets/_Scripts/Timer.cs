using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour {

    public int timerMax = 120;
    public int danceTime = 0;
    private bool isDancing = false;
    public float timerInterval = 1;
    private xxx control;

	// Use this for initialization
	void Start () {
        StartCoroutine(Countdown());
        control = GameObject.Find("DISPENSER").GetComponent<xxx>();
    }
	
	// Update is called once per frame
	void Update () {

        isDancing = control.GetDanceStatus();

        if (isDancing)
            Debug.Log("ISDANCING");
            //StartCoroutine(DanceTime());
        else
        Debug.Log("NO DANCING");
        //StopCoroutine(DanceTime());
    }

    IEnumerator Countdown()
    {
        while(true)
        {
            yield return new WaitForSeconds(timerInterval);
            timerMax -= 1;
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

    public void ResetTimer()
    {
        danceTime = 0;
        timerMax = 120;
    }
}
