using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Invector.CharacterController;

public class UdoPlayer : MonoBehaviour {

     float love = 9;
    float health = 7;
     float sanity = 8;
    public bool isAlive = true;
    public float loveRegen = 0;
    public float healthRegen = 0;
    public float sanityRegen = 0;
    public string lastDrug;
    public float killLevel = 0;

    private Material haut;
    protected vThirdPersonController tpcs;
    protected vThirdPersonInput tpis;

    private Color skinHealthy = new Color(1F, 1F, 1F, 1F);
    private Color skinUnhealthy = new Color(1F, 0.7F, 0.7F, 0.1F);

    private AudioSource _audioSource;
    public AudioClip _audioClip0;
    public AudioClip _audioClip1;

    private GameObject guiD;


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
    public bool getAlive()
    {
        return isAlive;
    }
    public float getKillLevel()
    {
        return killLevel;
    }
    public void Resurrect()
    {

        restStats();
        isAlive = true; 
        guiD.SetActive(false);
        tpis.enableMovement = true;
        Debug.Log("RESURRECTED");
    }
    public void restStats()
    {
         love = 9;
         health = 7;
         sanity = 8;
    }

    private List<Drug> drugList;


    public void consumeDrug(Drug stoff)
    {
        love += stoff.love;
        health += stoff.health;
        sanity += stoff.sanity;
        drugList.Add(stoff);
    }
    
    

	void Start ()
    {
        drugList = new List<Drug>();
        haut = GetComponentInChildren<Renderer>().material;
        tpcs = GameObject.Find("UDO").GetComponent<vThirdPersonController>();
        tpis = GameObject.Find("UDO").GetComponent<vThirdPersonInput>();
        _audioSource = GetComponent<AudioSource>();
        guiD = GameObject.Find("Death");

        guiD.SetActive(false);
    }
	


	void Update () {

        // CALCULATE KILL LEVEL
        killLevel = 10 - health;

        haut.color = Color.Lerp(skinUnhealthy, skinHealthy, health * .1f);


        love = MinMax(love, loveRegen);
        health = MinMax(health, healthRegen);
        sanity = MinMax(sanity, sanityRegen);

        if (health <= 0 && isAlive)
        {
            _audioSource.PlayOneShot(_audioClip0);
            //_audioSource.PlayOneShot(_audioClip1);
            StartCoroutine(JustDied());
            isAlive = false;
            tpcs.Death();
           // ee.enableMovement = false;
        }
        

    }


    float MinMax(float x, float regen)
    {
        if (x < 10 && x > 0)
            x += Time.deltaTime * regen;
        else if (x >= 10)
            x = 10;
        else if (x <=0)
            x = 0;
        return x; 
    }

    float Map(float s, float a1, float a2, float b1, float b2)
    {
        return b1 + (s - a1) * (b2 - b1) / (a2 - a1);
    }
    
    IEnumerator JustDied()
    {
        Debug.Log("JustDied");

        // DEATH SCREEN
        yield return new WaitForSecondsRealtime(3);
        guiD.SetActive(true);
    }
    

}
