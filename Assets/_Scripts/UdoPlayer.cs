using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UdoPlayer : MonoBehaviour {

    private float love = 50;
    private float speed = 50;
    private float creativity = 20;
    private float health;

    public float getLove()
    {
        return love;
    }
    public float getSpeed()
    {
        return speed;
    }
    public float getCreativity()
    {
        return creativity;
    }
    public float getHealth()
    {
        return health;
    }

    private List<Drug> drugList;


    public void consumeDrug(Drug stoff)
    {
        love += stoff.love;
        speed += stoff.speed;
        creativity += stoff.creativity;
        drugList.Add(stoff);
    }


	// Use this for initialization
	void Start () {
        drugList = new List<Drug>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
