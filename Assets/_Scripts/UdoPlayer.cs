using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Invector.CharacterController;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class UdoPlayer : MonoBehaviour {


    public static UdoPlayer Instance { get; private set; }


    float weed = .2f;
    float coke = .3f;
    float mdma = .4f;
    
    //float weed = .8f;
    //float coke = .8f;
    //float mdma = .8f;
    
    Vector3 statsOld;


    private ParticleSystem particleFloor;

    /*
    private float loveRegen = -0.01f;
    private float healthRegen = -0.01f;
    private float sanityRegen = -0.01f;
    */
    public string lastDrug;       

    private Material haut;
    protected vThirdPersonController tpcs;
    protected vThirdPersonInput tpis;
    private AudioSource _audioSource;
    public AudioClip audioDeathBody;
    public AudioClip audioDeathFx;
    private Animator udoAni;
    private GameObject udoObj;

    private Color skinHealthy = new Color(1F, 1F, 1F, 1F);
    private Color skinUnhealthy = new Color(1F, 0.85F, 0.85F, 0.1F);

    public bool isAlive = true;
    public float toxicationBonus = 0;
    private int timer = 90;
    private int score = 0;
    private float danceStyle = 0;
    private bool superMove = false;
    private float superMoveMultiplier = 1f;
    private bool isDancing = false;


    private void Awake()
    {
        particleFloor = GetComponentInChildren<ParticleSystem>();
        particleFloor.Play();
        particleFloor.Emit(0);

        if (Instance != null)
        {
            DestroyImmediate(gameObject);
            return;
        }
        Instance = this;
    }

    private List<Drug> drugList;


    void Start()
    {
        drugList = new List<Drug>();
        udoObj = GameObject.Find("UDO");
        haut = GetComponentInChildren<Renderer>().material;
        tpcs = udoObj.GetComponent<vThirdPersonController>();
        tpis = udoObj.GetComponent<vThirdPersonInput>();
        udoAni = udoObj.GetComponent<Animator>();

        _audioSource = GetComponent<AudioSource>();

        StartCoroutine(Countdown());
    }



    void Update()
    {
        if (Input.GetAxis("TriggerL") >= 1)
            isDancing = true;
        else
            isDancing = false;


        toxicationBonus = coke + mdma + weed + superMoveMultiplier;



        // THE HIGHSCORE        
        if (superMove)
            superMoveMultiplier = 2;
        else
            superMoveMultiplier = 0;

        if (isDancing && isAlive || superMove)
        score += (Mathf.RoundToInt(toxicationBonus));       


        // MANIPULATE UDO MODEL
        udoAni.speed = ExtensionMethods.Remap(toxicationBonus, 0, 3, .9f, 1.1f);
        haut.color = Color.Lerp(skinHealthy, skinUnhealthy, coke);
        //Debug.Log("coke _ " + coke);
        //Debug.Log("toxicationBonus _ " + toxicationBonus);

        
        // KILL IF FALL FROM PLATTFORM
        if (udoObj.transform.position.y <= -30)
            StartCoroutine(Death());


        // CHECK ALIVE
        if (weed >= 1 && isAlive || coke >= 1 && isAlive || mdma >= 1 && isAlive)
        {
            _audioSource.PlayOneShot(audioDeathFx);
            isAlive = false;
            StartCoroutine(Death());
            _audioSource.PlayOneShot(audioDeathBody);
            tpcs.Death();
        }


        CheckDanceStyle();
        //RegenStats();

    }

    public void consumeDrug(Drug stoff)
    {
        StartCoroutine(StatsOldDelay());
        coke += stoff.coke;               
        mdma += stoff.mdma;
        weed += stoff.weed;

        if (coke < 0)
            coke = 0.01f;
        if (mdma < 0)
            mdma = 0.01f;
        if (weed < 0)
            weed = 0.01f;

        drugList.Add(stoff);
    }

    public void PaySupermove(float[] x)
    {
        StartCoroutine(StatsOldDelay());
               
        coke -= x[0];
        mdma -= x[1];
        weed -= x[2];
    }

    /*
    private void RegenStats()
    {
        weed = Regeneration(weed, loveRegen);
        coke = Regeneration(coke, healthRegen);
        mdma = Regeneration(mdma, sanityRegen);
    }
    */

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

    IEnumerator StatsOldDelay()
    {
        statsOld = new Vector3(coke, mdma, weed);
        yield return new WaitForSeconds(3);
        statsOld = new Vector3(coke, mdma, weed);
    }



    private void GameOver()
    {
        isAlive = false;
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
            danceStyle = 0f;

        if (mdma > coke && mdma > weed)
            danceStyle = 0.5f;
    }

    public void SetBonusPoints(int x)
    {
        score += x;
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

    public void SetSuperMove(bool x)
    {
        superMove = x;
    }
    public Vector3 GetStatsOld()
    {
        return statsOld;
    }

    public Vector3 GetPos ()
    {
        return this.transform.position;
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

    public bool CheckCosts(float[] costs)
    {
        if (coke - costs[0] > 0 && mdma - costs[1] > 0 && weed - costs[2] > 0)
            return true;
        else
            return false;
    }

    public void SetParticleFloor(bool x)
    { 
        if (x)
            particleFloor.Emit(1);
        else
            particleFloor.Emit(0);
    }

    
}
