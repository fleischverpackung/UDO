using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Invector.CharacterController;

public class AnimationControl : MonoBehaviour {

    private Animator animator;
    private vThirdPersonInput assetInput;
    private vThirdPersonCamera assetCamera;
    private vThirdPersonController assetController;
    private vThirdPersonCamera assetCam;

    //private bool isDancing = false;
    private bool danceMode1 = false;
    private bool udoAlive = true;

    private float udoLove = 0;
    private float udoHealth = 0;
    private float udoSanity = 0;


    private float dance = 0;
    private float danceStyle = 0;

    private bool mode1 = false;
    private bool mode2 = false;
    private bool mode3 = false;

    private float camDistance = 6;
    private bool setCam = false;
    
    private bool danceStyleBool = false;
    private bool DanceMode1 = false;

    /// <summary>
    /// ////////////////////////////////////
    /// </summary>

    private bool isDancing = false;
    private bool camRotate = false;


    private void Awake()
    {
        GameObject x = GameObject.Find("UDO");
        assetInput = x.GetComponent<vThirdPersonInput>();
        assetController = x.GetComponent<vThirdPersonController>();
        animator = x.GetComponent<Animator>();

        assetCam = GameObject.Find("CamFollows").GetComponent<vThirdPersonCamera>();
    }

    void Start () {
        
    }
	


	void Update () {

        if (UdoPlayer.Instance != null)
        {
            
            //setCam = GamePadControl.Instance.GetCamMode();
            //danceStyle = UdoPlayer.Instance.GetToxicationBonus();
            //udoSanity = UdoPlayer.Instance.GetMdma();
            //udoHealth = UdoPlayer.Instance.GetCoke();
            //udoLove = UdoPlayer.Instance.GetWeed();

            isDancing = UdoPlayer.Instance.GetIsDancing();
            udoAlive = UdoPlayer.Instance.getAlive();

        }

        if( Input.GetAxisRaw("TriggerR") != 0)
            assetInput.enableCamRotate = true;
        else
            assetInput.enableCamRotate = false;


        //assetInput.enableMovement = udoAlive;
        if (isDancing || !udoAlive)
            assetInput.enableMovement = false;
        else
            assetInput.enableMovement = true;


        animator.SetFloat("DanceMode", UdoPlayer.Instance.GetDanceStyle());
        animator.SetFloat("IsDancing", System.Convert.ToSingle(UdoPlayer.Instance.GetIsDancing()));
        animator.SetFloat("DanceStyle", Input.GetAxis("Horizontal"));
        animator.SetFloat("DanceHard", Input.GetAxis("Vertical"));

        ZoomDiscance();

        /*
        if (setCam)
            assetInput.enableCamRotate = true;
        else
            assetInput.enableCamRotate = false;
            */


        // ZOOM
        

        


        //Debug.Log("NEW MOVES:: " + newMoves);

        /*
        // UGLY SET ANIMATOR FLOAT
        if (isDancing)
            dance = 1f;
        else
            dance = 0f;
        
        if (danceMode1)
            mode1 = true;
        else
            mode1 = false;

    */





        //Debug.Log(danceStyle);

        // DEACTIVATE MOVEMENT WHEN DEAD


        // ANIMATOR CONTROL
        //animator.SetFloat("DanceMode", trigger);





        //if (isDancing)
        //   animator.SetBool("DanceMode1", mode1);
        //animator.SetBool("DanceMode2", mode2);
        //animator.SetBool("DanceMode3", mode3);




        // DANCEMODE



        /*
        if (danceMode1 && udoAlive)
            assetInput.enableMovement = false;
        
        if (!isDancing && udoAlive)
            assetInput.enableMovement = true;
        */





    }

    private void ZoomDiscance()
    {
        float wheel = Input.GetAxis("DigiY") * 0.2f;
        if (camDistance >= 1.0)
            camDistance -= wheel;
        else
            camDistance = 1.1f;
        if (camDistance <= 7.1f)
            camDistance -= wheel;
        else
            camDistance = 7f;

        assetCam.defaultDistance = camDistance;
    }

}
