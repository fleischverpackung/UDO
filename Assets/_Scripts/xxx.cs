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
        inputScript = GameObject.Find("UDO").GetComponent<vThirdPersonInput>();
        
        distance = 6;
    
    }
    
    void Update()
    {
        
        float wheel = Input.GetAxis("Mouse ScrollWheel") * 4;

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
        float triggerL = Input.GetAxis("TriggerL");
        float triggerR = Input.GetAxis("TriggerR");


        // Im Animation Controller auf BOOL umbauen
        float isDancing = 0;
         if ((triggerL + triggerR) * 0.5f > 0.8f)
            isDancing = 1;

        


        anim.SetFloat("IsDancing", isDancing);
        anim.SetFloat("DanceStyle", Input.GetAxis("Horizontal"));
        anim.SetFloat("DanceHard", Input.GetAxis("Vertical"));

        //Debug.Log("X - " + Input.GetAxis("X"));
        //Debug.Log("Y - " + Input.GetAxis("Y"));
        //Debug.Log(Input.GetAxis("Run"));


        //Disable Cam Movement when Dancing
        if (isDancing > 0.8f)
        {
            Debug.Log("DANCE MODE");
            //inputScript.rotateCameraXInput = "blank";
            //inputScript.rotateCameraYInput = "blank";

            //inputScript.rotateCameraXInput += Time.deltaTime * 1;
            //inputScript.rotateCameraYInput += Time.deltaTime * 1;            
          
            inputScript.enableCamRotate = false;
            inputScript.enableMovement = false;
        }
        else
        {
            

            inputScript.enableMovement = true;
            inputScript.enableCamRotate = true;

        }

        



    }


}
