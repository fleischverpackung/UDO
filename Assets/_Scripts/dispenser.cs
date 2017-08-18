using UnityEngine;
using System.Collections;

public class dispenser : MonoBehaviour
{
    
    private GameObject[] liveDrugs;

    public GameObject[] prefabs;
    public int numberOfObjects = 20;
    public float radius = 5f;
    public float size = 1;

    void Start()
    {
        /*
        for (int i = 0; i < numberOfObjects; i++)
        {
            int drugCase = (Random.Range(0, 100)%prefabs.Length);

            
            float angle = i * Mathf.PI * 2 / numberOfObjects;
            Vector3 pos = new Vector3(Mathf.Cos(angle), 5, Mathf.Sin(angle)) * radius;
            Instantiate(prefabs[drugCase], pos, Quaternion.identity);
            
        }
        */

        StartCoroutine(DispenserOn());

    }

   
    void Update()
    {

        

    }

    IEnumerator DispenserOn()
    {
        while (true)
        {
            int drugCase = (Random.Range(0, 100) % prefabs.Length);
            Vector3 pos = new Vector3(Random.Range(-size, size), 5, Random.Range(-size, size));
            Instantiate(prefabs[drugCase], pos, Quaternion.identity);

            Debug.Log("dispensed Drug");
            yield return new WaitForSecondsRealtime(5);
        }
        

    }


}


    



