using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Invector.CharacterController;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class UdoPlayer :  MonoBehaviour {
    

    public static UdoPlayer Instance { get; private set; }


    float weed = .2f;
    float coke = .3f;
    float mdma = .4f;
    
    public bool isAlive = true;
    private float loveRegen = -0.01f;
    private float healthRegen = -0.0f;
    private float sanityRegen = -0.01f;
    public string lastDrug;


    public float toxicationBonus = 0;

    private Material haut;
    protected vThirdPersonController tpcs;
    protected vThirdPersonInput tpis;

    private Color skinHealthy = new Color(1F, 1F, 1F, 1F);
    private Color skinUnhealthy = new Color(1F, 0.7F, 0.7F, 0.1F);

    private AudioSource _audioSource;
    public AudioClip _audioClip0;

    private Animator udoAni;

    private int timer = 90;
    private int score = 0;
    private int danceTime = 0;
    private float danceStyle = 0;

    private bool isDancing = false;


    private void Awake()
    {
        if (Instance != null)
        {
            DestroyImmediate(gameObject);
            return;
        }
        Instance = this;        
    }    

    private List<Drug> drugList;    
    

	void Start ()
    {
        drugList = new List<Drug>();
        haut = GetComponentInChildren<Renderer>().material;
        tpcs = GameObject.Find("UDO").GetComponent<vThirdPersonController>();
        tpis = GameObject.Find("UDO").GetComponent<vThirdPersonInput>();
        _audioSource = GetComponent<AudioSource>();
        udoAni = GameObject.Find("UDO").GetComponent<Animator>();

        StartCoroutine(Countdown());
    }



    void Update ()
    {
        if (Input.GetAxis("TriggerL") >= 1)
            isDancing = true;
        else
            isDancing = false;
        
                
        toxicationBonus = coke + mdma + weed;

        if (isDancing && isAlive)
            score += (Mathf.RoundToInt(toxicationBonus));

        
        

        udoAni.speed = ExtensionMethods.Remap(toxicationBonus, 0, 1, .9f, 1.2f);
        haut.color = Color.Lerp(skinHealthy, skinUnhealthy,  coke);

        
        

        // CHECK ALIVE
        if (weed >= 1 && isAlive || coke >= 1 && isAlive || mdma >= 1 && isAlive)
        {
            isAlive = false;
            StartCoroutine(Death());
            _audioSource.PlayOneShot(_audioClip0);            
            tpcs.Death();            
        }
        

        CheckDanceStyle();
        RegenStats();

    }

    public void consumeDrug(Drug stoff)
    {
        weed += stoff.weed;
        coke += stoff.coke;
        mdma += stoff.mdma;
        drugList.Add(stoff);
    }

    private void RegenStats()
    {
        weed = Regeneration(weed, loveRegen);
        coke = Regeneration(coke, healthRegen);
        mdma = Regeneration(mdma, sanityRegen);
    }
    
    IEnumerator Death()
    {
        yield return new WaitForSecondsRealtime(5);
        GameOver();
    }

    IEnumerator Countdown()
    { 
        while (true)
        {            
            timer -= 1;
            if (timer <= 0)
                GameOver();
            yield return new WaitForSeconds(1);
        }
    }

    private void GameOver()
    {        
        Debug.Log("GAME OVER");
        Boot.Instance.setHighscore(score);
        PlayerPrefs.SetInt("finalScore", score);
        SceneManager.LoadScene("Splash");
    }

    private void CheckDanceStyle()
    {
        if (coke > weed && coke > mdma)
            danceStyle = 1;        

        if (weed > coke && weed > mdma)
            danceStyle = 0.5f;        

        if (mdma > coke && mdma > weed)
            danceStyle = 0;        
    }
    

    public float GetWeed()
    {
        return weed;
    }
    public float GetCoke()
    {
        return coke;
    }
    public float GetMdma()
    {
        return mdma;
    }
    public string getLastDrug()
    {
        return lastDrug;
    }
    public bool getAlive()
    {
        return isAlive;
    }

    public float GetToxicationBonus()
    {
        return toxicationBonus;
    }

    public int GetScore()
    {
        return score;
    }

    public bool GetIsDancing()
    {
        return isDancing;
    }

    public int GetTimer()
    {
        return timer;
    }

    public float GetDanceStyle()
    {
        return danceStyle;
    }

    public void Destroy()
    {
        Destroy(this);
    }


    float Regeneration(float x, float regen)
    {
        if (x < 10 && x > 0)
            x += Time.deltaTime * regen;
        else if (x >= 10)
            x = 10;
        else if (x <= 0)
            x = 0;
        return x;
    }

    
}
