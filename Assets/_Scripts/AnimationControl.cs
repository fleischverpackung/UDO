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

    private KeyCombo falconPunch = new KeyCombo(new string[] { "AB", "AB", "BB" });
    private KeyCombo falconKick = new KeyCombo(new string[] { "AB", "XB", "YB" });


    private bool udoAlive = true;
    private float danceStyle = 0;
    private float camDistance = 6;
    private bool setCam = false;
    private bool isDancing = false;
    private bool camRotate = false;

    private bool btnA = false;
    private bool btnB = false;
    private bool btnX = false;
    private bool btnY = false;

    private List<string> btnSequence = new List<string>(); 


    private void Awake()
    {
        GameObject x = GameObject.Find("UDO");
        assetInput = x.GetComponent<vThirdPersonInput>();
        assetController = x.GetComponent<vThirdPersonController>();
        animator = x.GetComponent<Animator>();
        assetCam = GameObject.Find("CamFollows").GetComponent<vThirdPersonCamera>();
    }

    

	void Update () {


        //Debug.Log("BUTTON A: " + btnA);

        if (UdoPlayer.Instance != null)
        {            
            isDancing = UdoPlayer.Instance.GetIsDancing();
            udoAlive = UdoPlayer.Instance.getAlive();
        }

        if( Input.GetAxisRaw("TriggerR") != 0)
            assetInput.enableCamRotate = true;
        else
            assetInput.enableCamRotate = false;

        
        if (isDancing || !udoAlive)
            assetInput.enableMovement = false;
        else
            assetInput.enableMovement = true;

      

    
        if (falconPunch.Check())
        {            
            Debug.Log("PUNCH");
        }
        if (falconKick.Check())
        {            
           Debug.Log("KICK");
        }
    


    animator.SetFloat("DanceMode", UdoPlayer.Instance.GetDanceStyle());
        animator.SetFloat("IsDancing", System.Convert.ToSingle(UdoPlayer.Instance.GetIsDancing()));
        animator.SetFloat("DanceStyle", Input.GetAxis("Horizontal"));
        animator.SetFloat("DanceHard", Input.GetAxis("Vertical"));

        ZoomDiscance();
        GetButtons();

        

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

    private void GetButtons()
    {
        btnA = Input.GetButtonDown("AB");
        btnB = Input.GetButtonDown("BB");
        btnX = Input.GetButtonDown("XB");
        btnY = Input.GetButtonDown("YB");
    }

}
