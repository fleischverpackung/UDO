using UnityEngine;
using System.Collections;

public class dispenser : MonoBehaviour
{
    
    //private GameObject[] liveDrugs;
    private AudioSource _audioSource;
    public AudioClip _audioClip;

    private bool active = true;

    public GameObject[] prefabs;
    public float dropArea = 10;
    public float dispenseInterval = 15;
    

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        StartCoroutine(DispenserOn());

    }

   
    void Update()
    {

        // INTENSIFY DROPPINGS
        while (dispenseInterval >=5 )
            dispenseInterval -= Time.deltaTime;
        


    }

    IEnumerator DispenserOn()
    {
        if (UdoPlayer.Instance.getAlive())
            
        {
            while (active)
            { int drugCase = (Random.Range(0, 3));
                Vector3 pos = new Vector3(Random.Range(-dropArea, dropArea), 5, Random.Range(-dropArea, dropArea));
                Instantiate(prefabs[drugCase], pos, Quaternion.identity);

                _audioSource.PlayOneShot(_audioClip);

                yield return new WaitForSecondsRealtime(dispenseInterval);
            }
        }      

    }

    
    


    private void OnDestroy()
    {
        StopCoroutine(DispenserOn());
    }


}


    



