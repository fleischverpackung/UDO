using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Instructions : MonoBehaviour {


    public Image instructions0;
    public Image instructions1;
    public Image instructions2;
    private int counter = 0;

    // Use this for initialization
    void Start () {

        instructions0.enabled = true;
        instructions1.enabled = false;
        instructions2.enabled = false;

    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetButtonDown("Start"))
            counter += 1;

        if (counter == 0)
        {
            instructions0.enabled = true;
            instructions1.enabled = false;
            instructions2.enabled = false;
        }

        if (counter == 1)
        {
            instructions0.enabled = false;
            instructions1.enabled = true;
            instructions2.enabled = false;
        }

        if (counter == 2)
        {
            instructions0.enabled = false;
            instructions1.enabled = false;
            instructions2.enabled = true;
            SceneManager.LoadScene("Dance");

        }
        


    }
}
