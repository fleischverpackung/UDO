using UnityEngine;
using System.Collections;

public class dispenser : MonoBehaviour
{

    public bool doDispense = false;

    public GameObject[] prefabs;
    public int numberOfObjects = 20;
    public float radius = 5f;

    void Start()
    {
        for (int i = 0; i < numberOfObjects; i++)
        {
            int drugCase = (Random.Range(0, 100)%prefabs.Length);

            float angle = i * Mathf.PI * 2 / numberOfObjects;
            Vector3 pos = new Vector3(Mathf.Cos(angle), 1, Mathf.Sin(angle)) * radius;
            Instantiate(prefabs[drugCase], pos, Quaternion.identity);
        }
    }


    

    void Update()
    {
        
        if (doDispense)
        {
            
           

           

            


            
        }



    }
    


}


    



