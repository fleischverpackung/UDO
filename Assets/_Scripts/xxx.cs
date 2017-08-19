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

     private Animator anim;
     private vThirdPersonInput ic;
     private vThirdPersonCamera cs;
     private vThirdPersonController cc;
     private float distance;
     public float style;
     private UdoPlayer udo;
     public GameObject udoPrefab;
     private float health;

    private void Awake()
    {
        var newObject = Instantiate(udoPrefab, new Vector3(0, 3, 0), Quaternion.identity);
        newObject.name = "UDO";
    }

    void Start()
    {
        cs = GameObject.Find("CamFollows").GetComponent<vThirdPersonCamera>();
        ic = GameObject.Find("UDO").GetComponent<vThirdPersonInput>();
        cc = GameObject.Find("UDO").GetComponent<vThirdPersonController>();
        anim = GameObject.Find("UDO").GetComponent<Animator>();
        udo = GameObject.Find("UDO").GetComponent<UdoPlayer>();
        

        distance = 6;
    
    }
    
    void Update()
    {
        // CHECK DEATH
        health = udo.getHealth();
        if (health <= 0)
            cc.Death();
            ic.enableMovement = false;


        // ZOOMING
        float wheel = Input.GetAxis("DigiY") * 0.2f;
        if (distance >= 1.0)
            distance -= wheel;
        else
            distance = 1.1f;
        if (distance <= 7.1f)
            distance -= wheel;
        else
            distance = 7f;
        


        cs.defaultDistance = distance;
        
        float triggerL = Input.GetAxis("TriggerL");
        float triggerR = Input.GetAxis("TriggerR");
        float digiY = Input.GetAxis("DigiY");


        // Im Animation Controller auf BOOL umbauen
        float isDancing = 0;
         if ((triggerL + triggerR) * 0.5f > 0.8f)
            isDancing = 1;

        anim.SetFloat("IsDancing", isDancing);
        anim.SetFloat("DanceStyle", Input.GetAxis("Horizontal"));
        anim.SetFloat("DanceHard", Input.GetAxis("Vertical"));

        
        if (digiY > 0.8f)
        {
            Debug.Log("DIGI UP " + digiY);
        }

        //Disable Cam Movement when Dancing
        if (isDancing > 0.8f)
        {
            Debug.Log("DANCE MODE");
            
            ic.enableCamRotate = false;
            ic.enableMovement = false;
        }
        else
        {   
            ic.enableMovement = true;
            ic.enableCamRotate = true;
        }

        



    }


}
