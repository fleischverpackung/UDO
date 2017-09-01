using UnityEngine;
using System.Collections;

public class dispenser : MonoBehaviour
{

    public Object[] pickupPrefabs;
    private AudioSource _audioSource;
    public AudioClip[] _audioClip;

    //private bool active = true;

    
    private int dropArea = 20;
    private float dispenseInterval = 0.3f;
    private int timer = 0;
    private bool doDispense = false;
    private Vector3 posUdo;
    

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        StartCoroutine(DispenserOn());
        StartCoroutine(DispensorOverTime());
    }

   
    void Update()
    {
        timer = UdoPlayer.Instance.GetTimer();   
        posUdo = UdoPlayer.Instance.GetPos();
    }


    IEnumerator DispenserOn()
    {
        while (UdoPlayer.Instance.getAlive())
        {
            if (doDispense)
            {
                int drugCase = (Random.Range(0, 4));
                Vector3 pos = new Vector3(Random.Range(-dropArea, dropArea), 5, Random.Range(-dropArea, dropArea));
                if (Vector3.Distance(pos, posUdo) >= 2)
                {
                    Instantiate(pickupPrefabs[drugCase], pos, Quaternion.identity);

                    int rand = (Random.Range(0, 3));
                    _audioSource.PlayOneShot(_audioClip[rand]);

                    Debug.Log("Dropped Drug @ " + pos);
                }
                

            }
            yield return new WaitForSecondsRealtime(dispenseInterval);
        }
    }

    IEnumerator DispensorOverTime()
    {
        doDispense = true;
        Debug.Log("FastDispense");
        yield return new WaitForSecondsRealtime(7);
        Debug.Log("StopDispense");
        doDispense = false;
        yield return new WaitForSecondsRealtime(28);
        Debug.Log("FastDispense");
        doDispense = true;
        yield return new WaitForSecondsRealtime(7);
        doDispense = false;
        yield return new WaitForSecondsRealtime(48);

    }
    
    
    private void OnDestroy()
    {
        StopCoroutine(DispenserOn());
        StopCoroutine(DispensorOverTime());
    }

}


    



