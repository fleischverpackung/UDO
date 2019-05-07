using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Person : MonoBehaviour
{

    private Animator ani;
    private AudioClip[] yeahs;
    private AudioSource speaker;
    //private int yeahCount;


    void Start()
    {

       ani = GetComponent<Animator>();
       ani.SetInteger("level", Random.Range(0, 7));
       speaker = GetComponent<AudioSource>();
       yeahs = Resources.LoadAll<AudioClip>("Assets/_Audio/yeah/");
       // Debug.Log(yeahs.Length().ToString());
       //yeahCount = yeahs.Length();

    }

    void Update()
    {
        new WaitForSeconds(Random.Range(3, 10));
        ani.SetInteger("level", Random.Range(0, 8));
        //speaker.PlayOneShot(yeahs[1]);
        
    }
}
