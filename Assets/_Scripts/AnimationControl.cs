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

    // SINGLE MOVES // nix extra
    
    private KeyCombo GayTurn = new KeyCombo(new string[] { "AB", "AB", "AB"}, "Fabulous", new float[] { 0f, 0.2f, 0f }, 300);
    private KeyCombo HipHopFlip = new KeyCombo(new string[] { "XB", "XB", "XB"}, "Flip", new float[] { 0.3f, 0f, 0f }, 650);
    private KeyCombo Wave = new KeyCombo(new string[] { "BB", "BB", "BB"}, "Wave", new float[] { 0f, 0f, 0.3f }, 400);

    // DUAL MOVES // 200 extra
    private KeyCombo Gangnam = new KeyCombo(new string[] { "BB", "BB", "AB" }, "Gangnam", new float[] { 0f, 0.1f, 0.2f }, 850); //6.6    
    private KeyCombo Armed = new KeyCombo(new string[] { "BB", "BB", "XB" }, "Twerk", new float[] { 0.15f, 0f, 0.3f }, 1000); //10.5

    private KeyCombo HipHopLegs = new KeyCombo(new string[] { "AB", "AB", "BB" }, "Legwork", new float[] { 0f, 0.35f, 0.15f }, 1200); //10.6
    private KeyCombo StreetLife = new KeyCombo(new string[] { "AB", "AB", "XB"}, "Streetlife", new float[] { 0.15f, 0.35f, 0f }, 1400); //12,7


    private KeyCombo Down = new KeyCombo(new string[] { "XB", "XB", "BB" }, "Down", new float[] { 0.325f, 0f, 0.175f }, 1300);//down 11.5
    private KeyCombo StepUp = new KeyCombo(new string[] { "XB", "XB", "AB" }, "StepUp", new float[] { 0.3f, 0.15f, 0f }, 1100); //9,3

    // TRIPLE MOVES // 500 etrxa
    private KeyCombo Spinner = new KeyCombo(new string[] { "XB", "AB", "XB", "AB", "YB" }, "Spinner", new float[] { 0.45f, 0.3f, 0f }, 2050);
    private KeyCombo Thriller = new KeyCombo(new string[] { "XB", "AB", "BB", "BB", "AB", "XB", "YB" }, "Thriller", new float[] { 0.2f, 0.6f , 0.4f }, 3050);
    private KeyCombo MoreFabulous = new KeyCombo(new string[] { "AB", "BB", "AB", "BB", "YB" }, "MoreFabulous", new float[] { 0.1f, 0.4f, 0.2f }, 2100);
    private KeyCombo Twerk = new KeyCombo(new string[] { "AB", "AB", "XB", "XB" }, "Twerk", new float[] { 0.2f, 0.5f, 0f }, 2000); //15
    private KeyCombo Hips = new KeyCombo(new string[] { "XB", "XB", "BB", "YB" }, "CrazyHips", new float[] { 0.35f, 0f, 0.25f }, 1750); //12,7


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

        if( Input.GetAxisRaw("TriggerR") != 0  || !aniTimer.IsName("Free Movement"))
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
            Armed.Check();
            Down.Check();
            StepUp.Check();
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
