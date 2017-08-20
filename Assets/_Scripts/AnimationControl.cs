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

    private bool danceMode = false;
    private bool udoAlive = true;
    private float dance = 0;
    private float camDistance = 6;
    private bool setCam = false;

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
            udoAlive = UdoPlayer.Instance.getAlive();

        if (GamePadControl.Instance != null)
            danceMode = GamePadControl.Instance.GetDanceMode();

        if (GamePadControl.Instance != null)
            setCam = GamePadControl.Instance.GetCamMode();


        // UGLY SET ANIMATOR FLOAT
        if (danceMode)
            dance = 1f;
        else
            dance = 0f;

        
        // DEACTIVATE MOVEMENT WHEN DEAD
        assetInput.enableMovement = udoAlive;

        // ANIMATOR CONTROL
        animator.SetFloat("IsDancing", dance);
        animator.SetFloat("DanceStyle", Input.GetAxis("Horizontal"));
        animator.SetFloat("DanceHard", Input.GetAxis("Vertical"));


        // DANCEMODE
        if (danceMode && udoAlive)
        {
            assetInput.enableCamRotate = false;
            assetInput.enableMovement = false;
        }
        if (!danceMode && udoAlive)
        {
            assetInput.enableMovement = true;
            assetInput.enableCamRotate = true;
           
        }

        if (setCam)
        {
            camDistance = ExtensionMethods.Remap(Input.GetAxis("Y"), -1, 1, 1, 7);
            assetInput.freezeCam = true;
            //Debug.Log(ExtensionMethods.Remap(Input.GetAxis("Y"), -1, 1, 1, 7));
        }
        else
        {
            assetInput.enableCamRotate = true;
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
