using UnityEngine;
using System.Collections;

public class dispenser : MonoBehaviour
{
    
    //private GameObject[] liveDrugs;
    private AudioSource _audioSource;
    public AudioClip _audioClip;

    private bool active = true;

    public GameObject[] prefabs;
    public float dropArea = 1;
    public int dispenseInterval = 3;
    

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        StartCoroutine(DispenserOn());
    }

   
    void Update()
    {      

    }

    IEnumerator DispenserOn()
    {
        while (active)
        {
            int drugCase = (Random.Range(0, 3));
            Vector3 pos = new Vector3(Random.Range(-dropArea, dropArea), 5, Random.Range(-dropArea, dropArea));
            Instantiate(prefabs[drugCase], pos, Quaternion.identity);

            _audioSource.PlayOneShot(_audioClip);

            yield return new WaitForSecondsRealtime(dispenseInterval);
        }
        

    }

    private void OnDestroy()
    {
        StopCoroutine(DispenserOn());
    }


}


    



