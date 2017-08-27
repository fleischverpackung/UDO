using UnityEngine;
using System.Collections;

public class dispenser : MonoBehaviour
{
    
    //private GameObject[] liveDrugs;
    private AudioSource _audioSource;
    public AudioClip _audioClip;

    private bool active = true;

    public GameObject[] prefabs;
    private int dropArea = 20;
    private float dispenseInterval = 1;
    private int timer = 0;
    private bool doDispense = false;
    

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        StartCoroutine(DispenserOn());
        StartCoroutine(DispensorOverTime());

    }

   
    void Update()
    {
        timer = UdoPlayer.Instance.GetTimer();

        //CheckDispenser();

        
        // INTENSIFY DROPPINGS
        // while (dispenseInterval >=5 )
        //  dispenseInterval -= Time.deltaTime;



    }

    IEnumerator DispenserOn()
    {        
            while (UdoPlayer.Instance.getAlive())
            {
                if (doDispense)
                {
                    int drugCase = (Random.Range(0, 3));
                    Vector3 pos = new Vector3(Random.Range(-dropArea, dropArea), 5, Random.Range(-dropArea, dropArea));

                    Instantiate(prefabs[drugCase], pos, Quaternion.identity);

                    _audioSource.PlayOneShot(_audioClip);
                    Debug.Log("Dropped Drug @ " + pos);
                    
                }
                yield return new WaitForSecondsRealtime(dispenseInterval);
        }
    }

    IEnumerator DispensorOverTime()
    {
        //dispenseInterval = 1f;
        doDispense = true;
        Debug.Log("1");
        yield return new WaitForSecondsRealtime(5);
        Debug.Log("2");
        doDispense = false;
        yield return new WaitForSecondsRealtime(30);
        Debug.Log("3");
        doDispense = true;
        yield return new WaitForSecondsRealtime(5);
        doDispense = false;
        yield return new WaitForSecondsRealtime(50);

    }

    /*
    // optimieren bitte 
    private void CheckDispenser()
    {
        

        if (timer <= 50 && timer > 40 || timer < 90 && timer > 85)
        {
            dispenseInterval = 1f;
            doDispense = true;
        }
            
        else
        {
            dispenseInterval = 35;
            doDispense = false;
        }
        
    }
    */
    
    private void OnDestroy()
    {
        StopCoroutine(DispenserOn());
    }

}


    



