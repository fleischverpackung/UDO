using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum drugType { COCAIN, MDMA, WEED, DEFAULT };

public class Drug : MonoBehaviour, IDrug
{

    public float health;
    public float sanity;
    public float love;
    public GameObject DrugObject;
    public drugType type;

    // FINETUNE SETTINGS FOR DRUG GENERATOR
    public float healthMin;
    public float healthMax;
    public float sanityMin;
    public float sanityMax;
    public float loveMin;
    public float loveMax;


    AudioSource _audioSource;
    public AudioClip _audioClip;
    public GameObject _particle;
    private Light _light;

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _light = GetComponent<Light>();

        DrugObject = transform.GetChild(0).gameObject;
        this.setLevels();

        StartCoroutine(SelfDestruct());



    }

    


   
    public virtual void drugAnimation()
    {
        //default animation
        Debug.Log("default drug animation");
    }

    public virtual void setLevels()
    {
        love = 0;
        sanity = 0;
        health = 0;
    }

    void OnDestroy()
    {


    }

    void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            other.GetComponent<UdoPlayer>().consumeDrug(this);
            _audioSource.PlayOneShot(_audioClip);
            _light.enabled = false;


            Renderer[] renderers = GetComponentsInChildren<Renderer>();
            foreach (Renderer r in renderers)
                r.enabled = false;            
            Destroy(gameObject, _audioClip.length);


        }
    }

    IEnumerator SelfDestruct()
    {
        yield return new WaitForSecondsRealtime(5);
        Destroy(gameObject, _audioClip.length);
    }




    private void GenerateDrug(int speedMin, int speedMax, int creativeMin, int creativeMax, int loveMin, int loveMax, PrimitiveType obj)
    {
        health = Random.Range(speedMin, speedMax);
        sanity = Random.Range(creativeMin, creativeMax);
        love = Random.Range(loveMin, loveMax);
        //DrugMesh = GameObject.CreatePrimitive(obj);
    }




    // Spawn at random Position
    //Vector3 pos = new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10));

    //DrugMesh.transform.position = pos;
}

