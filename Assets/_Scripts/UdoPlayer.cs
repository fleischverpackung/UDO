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
    private float loveRegen = -0.1f;
    private float healthRegen = 0.01f;
    private float sanityRegen = 0.05f;
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

    private Animator udoAni;

    private UnityAction resurrectListener;


    private void Awake()
    {
        resurrectListener = new UnityAction(Resurrect);        
        if (Instance != null)
        {
            DestroyImmediate(gameObject);
            return;
        }
        Instance = this;
        //DontDestroyOnLoad(gameObject);
        
    }

    private void OnEnable()
    {
        EventManager.StartListening("udoResurrect", resurrectListener);
    }

    private void OnDisable()
    {
        EventManager.StopListening("udoResurrect", resurrectListener);
    }



    
    



    public void Resurrect()
    {

        restStats();
        isAlive = true;
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
        udoAni = GameObject.Find("UDO").GetComponent<Animator>();
    }



    void Update ()
    {        
        //killLevel = (health + sanity + love) * 0.3f;
        killLevel = 10 - health;
        //Debug.Log("KILLLEVEL: " + killLevel);

        udoAni.speed = ExtensionMethods.Remap(killLevel, 0, 10, .9f, 1.2f);
        haut.color = Color.Lerp(skinUnhealthy, skinHealthy, health * .1f);

        love = MinMax(love, loveRegen);
        health = MinMax(health, healthRegen);
        sanity = MinMax(sanity, sanityRegen);

        if (killLevel >= 10 && isAlive)
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

        // DEATH SCREEN
        yield return new WaitForSecondsRealtime(6);
        EventManager.TriggerEvent("guiDeathScreen");
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
        return killLevel;
    }

    public void Destroy()
    {
        Destroy(this);
    } 
}
