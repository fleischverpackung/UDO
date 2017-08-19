using UnityEngine;
using System.Collections;

public class dispenser : MonoBehaviour
{
    
    private GameObject[] liveDrugs;
    private AudioSource _audioSource;
    public AudioClip _audioClip;
    private bool active = true;

    public GameObject[] prefabs;
    public int numberOfObjects = 20;
    public float radius = 5f;
    public float size = 1;
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
            Vector3 pos = new Vector3(Random.Range(-size, size), 5, Random.Range(-size, size));
            Instantiate(prefabs[drugCase], pos, Quaternion.identity);
            _audioSource.PlayOneShot(_audioClip);

            Debug.Log("dispensed Drug");
            yield return new WaitForSecondsRealtime(dispenseInterval);
        }
        

    }


}


    



