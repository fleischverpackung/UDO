using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightControl : MonoBehaviour {


    public static LightControl Instance { get; private set; }

    public Light pointlight;

    private void Awake()
    {
        if (Instance != null)
        {
            DestroyImmediate(gameObject);
            return;
        }
        Instance = this;
    }


    void Start () {
		
	}
	


	void Update () {

		
	}

   
}
