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

    private bool isDancing = false;
    private bool danceMode1 = false;
    private bool udoAlive = true;

    private float dance = 0;
    private float danceStyle = 0;

    private bool mode1 = false;
    private bool mode2 = false;
    private bool mode3 = false;

    private float camDistance = 6;
    private bool setCam = false;
    
    private bool danceStyleBool = false;
    private bool DanceMode1 = false;


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

        if (UdoPlayer.Instance != null && GamePadControl.Instance != null)
        {
            udoAlive = UdoPlayer.Instance.getAlive();
            isDancing = GamePadControl.Instance.GetTriggerL();
            setCam = GamePadControl.Instance.GetCamMode();
            danceStyle = UdoPlayer.Instance.getKillLevel() * 0.1f;
            
        }
            
        
            


        //Debug.Log("NEW MOVES:: " + newMoves);


        // UGLY SET ANIMATOR FLOAT
        if (isDancing)
            dance = 1f;
        else
            dance = 0f;
        
        if (danceMode1)
            mode1 = true;
        else
            mode1 = false;
            
        
        if (udoAlive && isDancing)
        {

            if (0 < danceStyle && danceStyle <= 0.3f)
            {
                Debug.Log("DANCE MODE1");
                animator.SetFloat("danceStyle", 0);
            }
            
            if (0.3f < danceStyle && danceStyle <= 0.6f)
            {
                Debug.Log("DANCE MODE2");
                animator.SetFloat("danceStyle", 0.5f);
            }

            if (0.6f < danceStyle && danceStyle <= 1)
            {
                Debug.Log("DANCE MODE3");
                animator.SetFloat("danceStyle", 1f);
            }



        }
        


        // DEACTIVATE MOVEMENT WHEN DEAD
        assetInput.enableMovement = udoAlive;

        // ANIMATOR CONTROL
        //animator.SetFloat("DanceMode", trigger);
        animator.SetFloat("IsDancing", dance);
        //animator.SetFloat("DanceMode", danceStyle);
        animator.SetFloat("DanceStyle", Input.GetAxis("Horizontal"));
        animator.SetFloat("DanceHard", Input.GetAxis("Vertical"));


        //if (isDancing)
         //   animator.SetBool("DanceMode1", mode1);
        //animator.SetBool("DanceMode2", mode2);
        //animator.SetBool("DanceMode3", mode3);




        // DANCEMODE
        if (isDancing && udoAlive)
        {
            //Debug.Log("DANCE MODE");

            assetInput.enableMovement = false;
        }
        if (!isDancing && udoAlive)
        {
            assetInput.enableMovement = true;
        }


        if (danceMode1 && udoAlive)
        {
            assetInput.enableMovement = false;
        }
        if (!isDancing && udoAlive)
        {
            assetInput.enableMovement = true;
        }



        if (setCam)
        {
            assetInput.enableCamRotate = true;
        }
        
        else
        {
            assetInput.enableCamRotate = false;
        }
        

        // ZOOM
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
