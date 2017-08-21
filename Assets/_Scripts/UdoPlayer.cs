using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Invector.CharacterController;
using UnityEngine.Events;

public class UdoPlayer :  MonoBehaviour {
    

    public static UdoPlayer Instance { get; private set; }   

    float love = 9;
    float health = 7;
    float sanity = 8;
    
    public bool isAlive = true;
    private float loveRegen = 0.1f;
    private float healthRegen = 0.0f;
    private float sanityRegen = 0.1f;
    public string lastDrug;


    public float toxicationBonus = 0;

    private Material haut;
    protected vThirdPersonController tpcs;
    protected vThirdPersonInput tpis;

    private Color skinHealthy = new Color(1F, 1F, 1F, 1F);
    private Color skinUnhealthy = new Color(1F, 0.7F, 0.7F, 0.1F);

    private AudioSource _audioSource;
    public AudioClip _audioClip0;
    public AudioClip _audioClip1;

    private Animator udoAni;
    


    private void Awake()
    {
        
        
        if (Instance != null)
        {
            DestroyImmediate(gameObject);
            return;
        }
        Instance = this;
        //DontDestroyOnLoad(gameObject);
        
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
        udoAni = GameObject.Find("UDO").GetComponent<Animator>();
    }



    void Update ()
    {
        toxicationBonus = 10 - (health * 0.3333f + sanity * 0.3333f + love * 0.3333f);
        //toxicationBonus = ((10 - love) + (10 - sanity)) * 0.5f;
        //Debug.Log("KILLLEVEL: " + killLevel);

        udoAni.speed = ExtensionMethods.Remap(toxicationBonus, 0, 10, .9f, 1.2f);
        haut.color = Color.Lerp(skinUnhealthy, skinHealthy, health * .1f);

        love = MinMax(love, loveRegen);
        health = MinMax(health, healthRegen);
        sanity = MinMax(sanity, sanityRegen);

        if (love <= 0 && isAlive || health <= 0 && isAlive || sanity <= 0 && isAlive)
        {
            isAlive = false;
            StartCoroutine(JustDied());
            _audioSource.PlayOneShot(_audioClip0);            
            tpcs.Death();
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

    
    IEnumerator JustDied()
    {
        Debug.Log("JustDied");
        
        yield return new WaitForSecondsRealtime(5);
        EventManager.TriggerEvent("guiDeathScreen");
        Boot.Instance.setHighscore(Timer.Instance.GetHighscore());
        yield return new WaitForSecondsRealtime(3);
        EventManager.TriggerEvent("sceneSplash");
    }

    public float getLove()
    {
        return love;
    }
    public float getSpeed()
    {
        return health;
    }
    public float getSanity()
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
        return toxicationBonus;
    }

    public void Destroy()
    {
        Destroy(this);
    } 
}
