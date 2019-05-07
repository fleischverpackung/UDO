using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CrowdControl : MonoBehaviour
{
    public GameObject[] myPrefabs;
    private GameObject instance;
    public float x = 3;
    public float y = 4;
    public Vector2 distance = new Vector2(3, 6);
    private Vector3 pos;
    private Quaternion rot;

    void Start()
    {

        rot = GetComponentInParent<Transform>().rotation;
        pos = GetComponentInParent<Transform>().transform.position;
        pos.y = 0;
     

        

        for (int i = 0; i < x; i++)
        {
           
            for (int j = 0; j < y; j++)
            {
                instance = Instantiate(myPrefabs[Random.Range(0,2)], new Vector3(i*distance.x, 0, j*distance.y) + pos, rot);
                instance.name = "Fan_" + i.ToString() + "_" + j.ToString();
                //instance.AddComponent < Animator>();
                //instance.GetComponent<Animator>().runtimeAnimatorController = Resources.Load("Assets/_AnimationControl/nurse") as RuntimeAnimatorController;
                //instance.GetComponent<Animator>().SetInteger("level", Random.Range(0, 7));
                Debug.Log("RANDOM" + Random.Range(0, 7).ToString());
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
}
