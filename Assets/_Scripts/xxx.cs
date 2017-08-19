using UnityEngine;
using System.Collections;
using System.IO;
using Invector.CharacterController;
using UnityEngine.UI;

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
 */

public class xxx : MonoBehaviour
{

    private Animator anim;
    private vThirdPersonInput ic;
    private vThirdPersonCamera cs;
    private vThirdPersonController cc;

    private float distance;
    private float startbtn = 0;
    public float style;

    private UdoPlayer udo;
    public GameObject udoPrefab;
    private GameObject udoClone;
    private float health;
    private bool alive;
    private GameObject guiD;

    private void Awake()
    {
        udoClone = Instantiate(udoPrefab, new Vector3(0, 3, 0), Quaternion.identity);
        udoClone.name = "UDO";
    }

    void Start()
    {
        
        cs = GameObject.Find("CamFollows").GetComponent<vThirdPersonCamera>();
           
        cc = GameObject.Find("UDO").GetComponent<vThirdPersonController>();
        anim = GameObject.Find("UDO").GetComponent<Animator>();
        udo = GameObject.Find("UDO").GetComponent<UdoPlayer>();
        guiD = GameObject.Find("Death");
        

        distance = 6;
    
    }
    
    void Update()
    {
        alive = udo.getAlive();
        startbtn = Input.GetAxis("Start");

       

        // RESPAWN
        if (!alive && startbtn == 1)
        {
            udo.Resurrect();
            cc.Jump();
            //ic.enableMovement = true;
            /*
            udo.restStats();
            udo.setAlive(true);
            cc.Jump();
            ic.enableMovement = true;
            guiD.SetActive(false);
            */
        }


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


        // Im Animation Controller auf BOOL umbauen
        float isDancing = 0;
         if ((triggerL + triggerR) * 0.5f > 0.8f)
            isDancing = 1;

        anim.SetFloat("IsDancing", isDancing);
        anim.SetFloat("DanceStyle", Input.GetAxis("Horizontal"));
        anim.SetFloat("DanceHard", Input.GetAxis("Vertical"));


        // DANCEMODE
        if (isDancing > 0.8f && alive)
        {            
            ic.enableCamRotate = false;
            ic.enableMovement = false;
        }
        if (isDancing <= 0.8f && alive)
        {   
            ic.enableMovement = true;
            ic.enableCamRotate = true;
        }     



    }

    



}
