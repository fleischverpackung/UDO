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
    private vThirdPersonInput tpis;
    private vThirdPersonCamera cs;
    private vThirdPersonController tpcs;

    private float distance;
    private float startbtn = 0;
    public float style;

    private UdoPlayer udo;
    public GameObject udoPrefab;
    private GameObject udoClone;
    private float health;
    private bool alive;
    private GameObject guiD;

    float isDancing = 0;
    bool isDancingBool = false;

    private void Awake()
    {
        udoClone = Instantiate(udoPrefab, new Vector3(0, 3, 0), Quaternion.identity);
        udoClone.name = "UDO";
    }

    void Start()
    {
        
        cs = GameObject.Find("CamFollows").GetComponent<vThirdPersonCamera>();
        tpis = GameObject.Find("UDO").GetComponent<vThirdPersonInput>();
        tpcs = GameObject.Find("UDO").GetComponent<vThirdPersonController>();
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
            tpcs.Jump();
            tpis.enableMovement = true;
            
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
        if ((triggerL + triggerR) * 0.5f > 0.8f)
        {
            isDancing = 1;
            isDancingBool = true;
        }            
        else
        {
            isDancing = 0;
            isDancingBool = false;
        }

        anim.SetFloat("IsDancing", isDancing);
        anim.SetFloat("DanceStyle", Input.GetAxis("Horizontal"));
        anim.SetFloat("DanceHard", Input.GetAxis("Vertical"));


        // DANCEMODE
        if (isDancing > .8f && alive)
        {            
            tpis.enableCamRotate = false;
            tpis.enableMovement = false;
        }
        if (isDancing <= 0.8 && alive)
        {   
            tpis.enableMovement = true;
            tpis.enableCamRotate = true;
        }  
        
        

    }


    public bool GetDanceStatus()
    {
        return isDancingBool;
    }




}
