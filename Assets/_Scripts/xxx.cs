using UnityEngine;
using System.Collections;
using System.IO;
using Invector.CharacterController;
using UnityEngine.UI;
using UnityEngine.Events;


public class xxx : MonoBehaviour
{

    //private Animator anim;
    //private vThirdPersonInput tpis;
    //private vThirdPersonCamera cs;
    //private vThirdPersonController tpcs;

    private float distance;
    private float startbtn = 0;
    public float style;

    private UdoPlayer udo;
    public GameObject udoPrefab;
    private GameObject udoClone;
    private float health;
    
    private GameObject guiD;

    float isDancing = 0;
    bool isDancingBool = false;

    private bool danceMode = false;
    private bool udoAlive;


    private void Awake()
    {
        
    }
    

    void Start()
    {
        
        //cs = GameObject.Find("CamFollows").GetComponent<vThirdPersonCamera>();
       // tpis = GameObject.Find("UDO").GetComponent<vThirdPersonInput>();
        //tpcs = GameObject.Find("UDO").GetComponent<vThirdPersonController>();
       // anim = GameObject.Find("UDO").GetComponent<Animator>();
        udo = GameObject.Find("UDO").GetComponent<UdoPlayer>();
       // guiD = GameObject.Find("Death");        

        distance = 6;
    
    }
    
    void Update()
    {
        /*

        if (UdoPlayer.Instance != null)
            udoAlive = UdoPlayer.Instance.getAlive();

        if (GamePadControl.Instance != null)
            danceMode = GamePadControl.Instance.GetDanceMode();

        //Debug.Log("DANCEMODE " + danceMode);
        */

        startbtn = Input.GetAxis("Start");

       

        // RESPAWN
        if (!udoAlive && startbtn == 1)
        {
            udo.Resurrect();
          //  tpcs.Jump();
          //  tpis.enableMovement = true;
            
        }



        // ZOOMING
        /*
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

        */

        //float triggerL = Input.GetAxis("TriggerL");
        //float triggerR = Input.GetAxis("TriggerR");
        
        /*
        if (danceMode)
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
        if (danceMode && udoAlive)
        {            
            tpis.enableCamRotate = false;
            tpis.enableMovement = false;
        }
        if (!danceMode && udoAlive)
        {   
            tpis.enableMovement = true;
            tpis.enableCamRotate = true;
        }  
        
        */

    }


    public bool GetDanceStatus()
    {
        return isDancingBool;
    }




}
