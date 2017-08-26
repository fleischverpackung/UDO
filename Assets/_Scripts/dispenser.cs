using UnityEngine;
using System.Collections;

public class dispenser : MonoBehaviour
{
    
    //private GameObject[] liveDrugs;
    private AudioSource _audioSource;
    public AudioClip _audioClip;

    private bool active = true;

    public GameObject[] prefabs;
    public int dropArea = 8;
    private float dispenseInterval;
    private int timer = 0;
    private bool doDispense = false;
    

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        StartCoroutine(DispenserOn());

    }

   
    void Update()
    {
        timer = UdoPlayer.Instance.GetTimer();

        CheckDispenser();

        
        // INTENSIFY DROPPINGS
        // while (dispenseInterval >=5 )
        //  dispenseInterval -= Time.deltaTime;



    }

    IEnumerator DispenserOn()
    {        
            while (UdoPlayer.Instance.getAlive())
            {
                int drugCase = (Random.Range(0, 3));
                Vector3 pos = new Vector3(Random.Range(-dropArea, dropArea), 5, Random.Range(-dropArea, dropArea));

            
                Instantiate(prefabs[drugCase], pos, Quaternion.identity);       
                             
                _audioSource.PlayOneShot(_audioClip);
                Debug.Log("Dropped Drug @ " + pos);
                yield return new WaitForSecondsRealtime(dispenseInterval);
            }
    }

    private void CheckDispenser()
    {
        if (timer <= 50 && timer > 40 || timer < 90 && timer > 80)
        {
            dispenseInterval = 1;
            doDispense = true;
        }
            
        else
        {
            dispenseInterval = 30;
            doDispense = false;
        }
        
    }
    
    private void OnDestroy()
    {
        StopCoroutine(DispenserOn());
    }

}


    



