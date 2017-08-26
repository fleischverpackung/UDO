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

    private KeyCombo specialHipHopLegs = new KeyCombo(new string[] { "AB", "AB", "BB" });
    private KeyCombo specialGayTurn = new KeyCombo(new string[] { "YB", "YB", "XB" });
   // private KeyCombo special = new KeyCombo(new string[] { "XB", "YB" });
    //private KeyCombo falconKick = new KeyCombo(new string[] { "XB", "YB" });
    //private KeyCombo falconKick = new KeyCombo(new string[] { "XB", "YB" });

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

    private float time = 0;


    private void Awake()
    {
        GameObject x = GameObject.Find("UDO");
        assetInput = x.GetComponent<vThirdPersonInput>();
        assetController = x.GetComponent<vThirdPersonController>();
        animator = x.GetComponent<Animator>();
        assetCam = GameObject.Find("CamFollows").GetComponent<vThirdPersonCamera>();

    }

    

	void Update () {

        AnimatorStateInfo aniTimer = animator.GetCurrentAnimatorStateInfo(0);
        //AnimatorStateInfo aniTimer = animator.GetCurrentAnimatorClipInfo;
        time = aniTimer.normalizedTime;


        //Debug.Log("ANIMATORSTATE: " + aniTimer.IsName("Free Movement"));

        
        






        if (UdoPlayer.Instance != null)
        {            
            isDancing = UdoPlayer.Instance.GetIsDancing();
            udoAlive = UdoPlayer.Instance.getAlive();
        }

        if( Input.GetAxisRaw("TriggerR") != 0 || !aniTimer.IsName("Free Movement"))
            assetInput.enableCamRotate = true;
        else
            assetInput.enableCamRotate = false;

        
        if (isDancing || !udoAlive || !aniTimer.IsName("Free Movement"))
        {
            assetInput.enableMovement = false;
            assetInput.enableJump = false;
        }            
        else
        {
            assetInput.enableMovement = true;
            assetInput.enableJump = true;
        }

        


       
        // COMBOS
        if (specialHipHopLegs.Check())
        {
            Debug.Log("COMBO 1");
            animator.Play("Special HipHopLegs");
            StartCoroutine(CheckAniTime());
           
        }
        if (specialGayTurn.Check())
        {
            Debug.Log("COMBO 2");
            animator.Play("Special GayTurn");
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

    
    IEnumerator CheckAniTime()
    {
        

        while (!animator.GetCurrentAnimatorStateInfo(0).IsName("Free Movement"))
        {
            Debug.Log("Corouting");
            assetInput.enableMovement = false;
            assetInput.enableJump = false;
        }

        yield return new WaitForSeconds(1);



    }
    

}
