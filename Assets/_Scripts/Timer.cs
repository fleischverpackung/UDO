using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour {

    public int timerMax;
    public float timerInterval = 1;

	// Use this for initialization
	void Start () {
        StartCoroutine(Countdown());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator Countdown()
    {
        while(true)
        {
            yield return new WaitForSeconds(timerInterval);
            timerMax -= 1;
        }
        
    }

    public int GetTimer()
    {
        return timerMax;
    }
}
