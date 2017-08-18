using UnityEngine;
using System.Collections;
using System.IO;
using Invector.CharacterController;



/*
 * StateManager class (singleton) 
 *      - spielstatus
 *      - 
 * Player class 
 *      - druglevels
 *      (- possible moves)
 *      - health
 * 
 * Drug class/interface
 *      - übergeordnetet klasse von der jede droge erbt, z.b. Speed:Drug
 *      - oder interface, das gewisse methoden für alle drogen definiert
 *      Speed: IDrugs
 *      
 * 
 * 
 */

public class xxx : MonoBehaviour
{

     public Animator anim;
     vThirdPersonInput inputScript;
     vThirdPersonCamera cameraScript;
     float distance;

    
   
    public float style;
    //public float speed;

    // Use this for initialization
    void Start()
    {
        cameraScript = GameObject.Find("CamFollows").GetComponent<vThirdPersonCamera>();
        inputScript = GameObject.Find("odo neu").GetComponent<vThirdPersonInput>();

        
        
        

        distance = 6;
        //style = 0;
        //speed = 0;
        

        //anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        float wheel = Input.GetAxis("Mouse ScrollWheel")*4;

        if (distance >= 1.0)
        {
            distance -= wheel;
        }else
        {
            distance = 1.1f;
        }
        if (distance <= 7.1f)
        {
            distance -= wheel;
        }
        else
        {
            distance = 7f;
        }


        cameraScript.defaultDistance = distance;
        //Debug.Log("Distance: " + distance);

        /*
        if (Input.GetKeyDown(KeyCode.H))
        {
            Debug.Log("H");
            anim.SetBool("DanceFast", true);

        }
        */

        anim.SetFloat("IsDancing", Input.GetAxis("Dance"));
        anim.SetFloat("DanceStyle", Input.GetAxis("X"));
        anim.SetFloat("DanceHard", Input.GetAxis("Y"));

        //Debug.Log("X - " + Input.GetAxis("X"));
        //Debug.Log("Y - " + Input.GetAxis("Y"));
        //Debug.Log(Input.GetAxis("Run"));


        //Disable Cam Movement when Dancing
        if (Input.GetAxis("Dance") > 0.5f)
        {
            inputScript.rotateCameraXInput = "blank";
            inputScript.rotateCameraYInput = "blank";
        }
        else
        {
            inputScript.rotateCameraXInput = "X";
            inputScript.rotateCameraYInput = "Y";
        }


        
    }


}
