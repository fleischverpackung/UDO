using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CrowdControl : MonoBehaviour
{
    public GameObject[] myPrefabs;
    //private SkinnedMeshRenderer renderer;
    private int x = 5;
    private int y = 6;
    private float distance = 10;
    private Vector3 rotate = new Vector3(90, 0, 0);
    public Quaternion rotation;
    public AnimationControl animator;

    void Start()
    {
        
        // Instantiate at position (0, 0, 0) and zero rotation.
        //Instantiate(myPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        //renderer = myPrefab.GetComponent<SkinnedMeshRenderer>();
        int[,] array = new int[x, y];

        for (int i = 0; i < x; i++)
        {
            for (int j = 0; j < y; j++)
            {
                Instantiate(myPrefabs[Random.Range(0,2)], new Vector3(i*distance, 0, j*distance), Quaternion.identity*rotation);

            }
        }
        //GenerateArray(5, 2);
        //enderer.material.
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
}
