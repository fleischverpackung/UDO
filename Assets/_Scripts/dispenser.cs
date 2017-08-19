using UnityEngine;
using System.Collections;

public class dispenser : MonoBehaviour
{
    
    private GameObject[] liveDrugs;

    public GameObject[] prefabs;
    public int numberOfObjects = 20;
    public float radius = 5f;
    public float size = 1;
    public int dispenseInterval = 10;
    private bool active;

    void Start()
    {        
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

            Debug.Log("dispensed Drug");
            yield return new WaitForSecondsRealtime(dispenseInterval);
        }
        

    }


}


    



