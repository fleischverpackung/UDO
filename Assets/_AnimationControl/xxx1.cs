using UnityEngine;
using System.Collections;

public class xxx1 : MonoBehaviour
{

    public Animator myAnimator;
  
   
    public float style;
    //public float speed;

    // Use this for initialization
    void Start()
    {
        //style = 0;
        //speed = 0;
        //myAnimator = GameObject.Find("UdoAnimator").GetComponent<Animator>();
        myAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        //myAnimator.SetFloat("VSpeed", Input.GetAxis("Vertical"));

        myAnimator.SetFloat("DanceStyle", style);
        //myAnimator.SetFloat("DanceSpeed", speed);

    }


}
