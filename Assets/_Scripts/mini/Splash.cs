using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Splash : MonoBehaviour {


    public Image instructions;



    void Start () {
        instructions.enabled = false;

    }
	


	void Update () {

        if (Input.GetButtonDown("Select"))
        {
            instructions.enabled = !instructions.enabled;
            
        }

    }
}
