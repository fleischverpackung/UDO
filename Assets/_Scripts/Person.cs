using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Person : MonoBehaviour
{

    private Animator ani;
    private int info;

    // Start is called before the first frame update
    void Start()
    {
        info = Random.Range(0, 7);

       ani = GetComponent<Animator>();
       ani.SetInteger("level", info);

        Debug.Log(info.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
