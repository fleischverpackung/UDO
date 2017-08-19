using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TVflicker : MonoBehaviour {

    private Light screen;
	// Use this for initialization
	void Start () {
        screen = GetComponent<Light>();
	}
	
	// Update is called once per frame
	void Update () {
        screen.intensity = Random.Range(0.5f, 0.8f);


    }
}
