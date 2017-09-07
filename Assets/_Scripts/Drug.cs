using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum drugType { COCAIN, MDMA, WEED, MEDICINE, DEFAULT };

public class Drug : MonoBehaviour, IDrug
{

    public float coke;
    public float mdma;
    public float weed;
    public GameObject DrugObject;
    public drugType type;

    // FINETUNE SETTINGS FOR DRUG GENERATOR
    public float cokeMin;
    public float cokeMax;
    public float mdmaMin;
    public float mdmaMax;
    public float weedMin;
    public float weedMax;

    AudioSource _audioSource;
    public AudioClip _audioClip;
    public GameObject _particle;
    private Light _light;

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _light = GetComponentInChildren<Light>();
        DrugObject = transform.GetChild(0).gameObject;
        this.setLevels();
        StartCoroutine(SelfDestruct());
    }

    private void Update()
    {
        transform.Rotate (Vector3.up * 100 * Time.deltaTime, Space.Self);
    }

    
    public virtual void drugAnimation()
    {
        //default animation
        //Debug.Log("default drug animation");
    }

    public virtual void setLevels()
    {
        weed = 0;
        mdma = 0;
        coke = 0;
    }


    void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            other.GetComponent<UdoPlayer>().consumeDrug(this);
           _audioSource.PlayOneShot(_audioClip);
           
            Renderer[] renderers = GetComponentsInChildren<Renderer>();
            foreach (Renderer r in renderers)
            {
                r.enabled = false;
            }      
            // enable this when using spotlights on items
            //_light.enabled = false;

            Destroy(gameObject, _audioClip.length);
            
        }
    }
    



    IEnumerator SelfDestruct()
    {
        yield return new WaitForSecondsRealtime(6);        
        Destroy(gameObject, _audioClip.length);
    }


    private void GenerateDrug(int cokeMin, int cokeMax, int mdmaMin, int mdmaMax, int weedMin, int weedMax, PrimitiveType obj)
    {                                   
        coke = Random.Range(cokeMin, cokeMax);
        mdma = Random.Range(mdmaMin, mdmaMax);
        weed = Random.Range(weedMin, weedMax);
    }
}

