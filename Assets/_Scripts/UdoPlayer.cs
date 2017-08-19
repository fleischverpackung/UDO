using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Invector.CharacterController;

public class UdoPlayer : MonoBehaviour {

    public float love = 70;
    public float health = 60;
    public float sanity = 80;
    public float loveRegen = 0;
    public float healthRegen = 0;
    public float sanityRegen = 0;
    public string lastDrug;

    private Material haut;
    protected vThirdPersonController cc;
    protected vThirdPersonInput ee;



    public float getLove()
    {
        return love;
    }
    public float getSpeed()
    {
        return health;
    }
    public float getCreativity()
    {
        return sanity;
    }
    public float getHealth()
    {
        return health;
    }
    public string getLastDrug()
    {
        return lastDrug;
    }

    private List<Drug> drugList;


    public void consumeDrug(Drug stoff)
    {
        love += stoff.love;
        health += stoff.health;
        sanity += stoff.sanity;
        drugList.Add(stoff);
    }


	// Use this for initialization
	void Start () {
        drugList = new List<Drug>();
        haut = GetComponentInChildren<Renderer>().material;
        cc = GameObject.Find("UDO").GetComponent<vThirdPersonController>();
        ee = GameObject.Find("UDO").GetComponent<vThirdPersonInput>();
    }
	
	// Update is called once per frame
	void Update () {

        love += Time.deltaTime * loveRegen;
        health += Time.deltaTime * healthRegen;
        sanity += Time.deltaTime * sanityRegen;

        //haut.color = new Color(1.0f, .8f, .8f);

    }
}
