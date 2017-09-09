using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Invector.CharacterController;
using UnityEngine.UI;

public class AnimationControl : MonoBehaviour {

    public static AnimationControl Instance { get; private set; }

    private Animator animator;
    private vThirdPersonInput assetInput;
    private vThirdPersonCamera assetCamera;
    private vThirdPersonController assetController;
    private vThirdPersonCamera assetCam;

    // params: coke / mdma / weed !!!
    // punkte = dauer sec * 10 gerundet // kosten = * 0.05
    private KeyCombo HipHopLegs = new KeyCombo(new string[] { "AB", "XB", "AB" }, "Legwork", new float[]{0.16f, 0.16f, 0.16f}, 1000);
    private KeyCombo GayTurn = new KeyCombo(new string[] { "YB", "XB", "YB" }, "Fabulous", new float[] { 0f, 0.15f, 0f}, 300);
    private KeyCombo HipHopFlip = new KeyCombo(new string[] { "AB", "YB", "AB" }, "Flip", new float[] { 0.15f, 0, 0.08f}, 650);
    private KeyCombo Twerk = new KeyCombo(new string[] { "XB", "BB", "XB" }, "Twerk", new float[] { 0.25f, 0.25f, 0.25f }, 1500);
    private KeyCombo Gangnam = new KeyCombo(new string[] { "YB", "BB", "YB" }, "Gangnam", new float[] { 0f, 0.17f, 0.15f }, 650);
    private KeyCombo Thriller = new KeyCombo(new string[] { "YB", "AB", "XB" }, "Thriller", new float[] { 0.4f, 0.4f , 0.4f }, 2550);
    private KeyCombo StreetLife = new KeyCombo(new string[] { "YB", "BB", "XB" }, "Streetlife", new float[] { 0.3f, 0.15f, 0.15f }, 1250);
    private KeyCombo MoreFabulous = new KeyCombo(new string[] { "AB", "XB", "YB" }, "MoreFabulous", new float[] { 0.0f, 0.2f, 0.2f }, 1600);
    private KeyCombo Wave = new KeyCombo(new string[] { "BB", "AB", "BB" }, "Wave", new float[] { 0f, 0.3f, 0f }, 400);
    private KeyCombo Spinner = new KeyCombo(new string[] { "YB", "AB", "YB" }, "Spinner", new float[] { 0.4f, 0.35f, 0f }, 1550);
    private KeyCombo Hips = new KeyCombo(new string[] { "AB", "BB", "YB" }, "CrazyHips", new float[] { 0.3f, 0f, 0.3f }, 1250);

    private bool udoAlive = true;
    private float camDistance = 6;
    private bool isDancing = false;
    private bool isSupermove = false;
    private float time = 0;

    private bool btnA = false;
    private bool btnB = false;
    private bool btnX = false;
    private bool btnY = false;
    

    private void Awake()
    {
        GameObject x = GameObject.Find("UDO");
        assetInput = x.GetComponent<vThirdPersonInput>();
        assetController = x.GetComponent<vThirdPersonController>();
        animator = x.GetComponent<Animator>();
        assetCam = GameObject.Find("CamFollows").GetComponent<vThirdPersonCamera>();
        if (Instance != null)
        {
            DestroyImmediate(gameObject);
            return;
        }
        Instance = this;
    }
    

	void Update () {


        // CHECK CURRENT ANIMATION TIME
        AnimatorStateInfo aniTimer = animator.GetCurrentAnimatorStateInfo(0);
        time = aniTimer.normalizedTime;


        // GET IMPORTANT UDO VALUES
        if (UdoPlayer.Instance != null)
        {  
            isDancing = UdoPlayer.Instance.GetIsDancing();
            udoAlive = UdoPlayer.Instance.getAlive();
        }

        /*
        for (int i = 0; i < specialNames.Length; i++)
        {
            if (aniTimer.IsName(specialNames[i]))
            {
                isSupermove = true;
                UdoPlayer.Instance.SetSuperMove(true);
            }
            else
            {
                isSupermove = false;
                UdoPlayer.Instance.SetSuperMove(false);
            }
        }
        */
        
        // CHECK FOR SUPERMOVE STATE
        if (!aniTimer.IsName("Free Movement") && udoAlive && !aniTimer.IsName("Jump") && !aniTimer.IsName("Falling") && !aniTimer.IsName("Landing") && !aniTimer.IsName("Locomotion"))
        {
            isSupermove = true;
            UdoPlayer.Instance.SetSuperMove(true);
        }            
        else
        {
            isSupermove = false;
            UdoPlayer.Instance.SetSuperMove(false);
        }
           

        
        
        // CAM SPIN

        if( Input.GetAxisRaw("TriggerR") != 0 || !aniTimer.IsName("Free Movement"))
            assetInput.enableCamRotate = true;
        else
            assetInput.enableCamRotate = false;



        // FREEZE MOVEMENT

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

        if (!isSupermove)
        {
            HipHopLegs.Check();
            GayTurn.Check();
            HipHopFlip.Check();
            Twerk.Check();
            Gangnam.Check();
            Thriller.Check();
            StreetLife.Check();
            Wave.Check();
            Spinner.Check();
            MoreFabulous.Check();
            Hips.Check();
        }
        



        // DANCE MODES

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
            assetInput.enableMovement = false;
            assetInput.enableJump = false;
        }
        yield return new WaitForSeconds(1);
    }

    

    // EXTERNAL FUNCTIONS

    public void StartCoroutine()
    {
        StartCoroutine(CheckAniTime());
    }
    public void PlayAni(string x)
    {
        animator.Play(x);
    }
    public bool GetIsSupermove()
    {
        return isSupermove;
    }



}
