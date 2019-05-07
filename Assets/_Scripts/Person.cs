using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Person : MonoBehaviour
{

    private Animator ani;


    void Start()
    {
       ani = GetComponent<Animator>();
       ani.SetInteger("level", Random.Range(0, 7));
    }

    void Update()
    {
        new WaitForSeconds(Random.Range(3, 10));
        ani.SetInteger("level", Random.Range(0, 8));
    }
}
