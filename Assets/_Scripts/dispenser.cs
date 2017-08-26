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
    

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        StartCoroutine(DispenserOn());

    }

   
    void Update()
    {
        timer = UdoPlayer.Instance.GetTimer();
        //Debug.Log(dispenseInterval);
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

                SetDispenseTime();                

                _audioSource.PlayOneShot(_audioClip);
                Debug.Log("Dropped Drug @ " + pos);
                yield return new WaitForSecondsRealtime(dispenseInterval);
            }
    }

    private void SetDispenseTime()
    {
        if (timer < 90 && timer > 80)
            dispenseInterval = 1;
        if (timer <= 80 && timer > 50)
            dispenseInterval = 100;
        if (timer <= 50 && timer > 40)
            dispenseInterval = 1;
        if (timer <= 40 && timer > 1)
            dispenseInterval = 100;
        //if (timer == 0)
          //  dispenseInterval = 100;
    }
    
    private void OnDestroy()
    {
        StopCoroutine(DispenserOn());
    }

}


    



