using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum drugType { SPEED, MDMA, WEED, DEFAULT };

public class Drug : MonoBehaviour, IDrug
{

    public float speed;
    public float creativity;
    public float love;
    public GameObject DrugObject;
    public drugType type;


    AudioSource _audioSource;
    public AudioClip _audioClip;
    public GameObject _particle;

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();

        DrugObject = transform.GetChild(0).gameObject;
        this.setLevels();



    }

    


    //public Drug(int type)
    //{


    //    switch (type)
    //    {
    //        // Weed
    //        case 0:
    //            GenerateDrug(-10, +2, +2, +10, +3, +7, PrimitiveType.Capsule);
    //            break;

    //        // Cocain
    //        case 1:
    //            GenerateDrug(+10, +20, +2, +5, -5, -10, PrimitiveType.Cube);
    //            break;

    //        // Mdma
    //            GenerateDrug(-15, -10, -2, +5, +15, +25, PrimitiveType.Sphere);
    //        case 2:
    //            break;
    //    }
    //}

    public virtual void drugAnimation()
    {
        //default animation
        Debug.Log("default drug animation");
    }

    public virtual void setLevels()
    {
        love = 0;
        creativity = 0;
        speed = 0;
    }

    void OnDestroy()
    {


    }

    void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            other.GetComponent<UdoPlayer>().consumeDrug(this);
            Renderer[] renderers = GetComponentsInChildren<Renderer>();
            foreach (Renderer r in renderers)
                r.enabled = false;

            _audioSource.PlayOneShot(_audioClip);
            Destroy(gameObject, _audioClip.length);


        }
    }




    private void GenerateDrug(int speedMin, int speedMax, int creativeMin, int creativeMax, int loveMin, int loveMax, PrimitiveType obj)
    {
        speed = Random.Range(speedMin, speedMax);
        creativity = Random.Range(creativeMin, creativeMax);
        love = Random.Range(loveMin, loveMax);
        //DrugMesh = GameObject.CreatePrimitive(obj);
    }




    // Spawn at random Position
    //Vector3 pos = new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10));

    //DrugMesh.transform.position = pos;
}

