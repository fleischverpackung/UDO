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

    private void Awake()
    {
        assetInput = GameObject.Find("UDO").GetComponent<vThirdPersonInput>();
        assetController = GameObject.Find("UDO").GetComponent<vThirdPersonController>();
        animator = GameObject.Find("UDO").GetComponent<Animator>();
        assetCam = GameObject.Find("CamFollows").GetComponent<vThirdPersonCamera>();
    }

    void Start () {
        
    }
	


	void Update () {

        if (UdoPlayer.Instance != null)
            udoAlive = UdoPlayer.Instance.getAlive();

        if (GamePadControl.Instance != null)
            danceMode = GamePadControl.Instance.GetDanceMode();


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
