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
    private float dispenseInterval = 10;
    

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        StartCoroutine(DispenserOn());

    }

   
    void Update()
    {

        // INTENSIFY DROPPINGS
        // while (dispenseInterval >=5 )
        //  dispenseInterval -= Time.deltaTime;
        


    }

    IEnumerator DispenserOn()
    {
        
            while (UdoPlayer.Instance.getAlive())
            { int drugCase = (Random.Range(0, 3));
                Vector3 pos = new Vector3(Random.Range(-dropArea, dropArea), 5, Random.Range(-dropArea, dropArea));
                Instantiate(prefabs[drugCase], pos, Quaternion.identity);
                dispenseInterval = Random.Range(20, 30);

            _audioSource.PlayOneShot(_audioClip);
            Debug.Log(pos);
                yield return new WaitForSecondsRealtime(dispenseInterval);
            }
            

    }

    
    


    private void OnDestroy()
    {
        StopCoroutine(DispenserOn());
    }


}


    



