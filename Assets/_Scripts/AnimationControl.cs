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

    // params: weed / coke / mdma !!!
    private KeyCombo HipHopLegs = new KeyCombo(new string[] { "AB", "AB", "BB" }, "HipHopLegs", new float[]{0.2f, 0.1f, 0});
    private KeyCombo GayTurn = new KeyCombo(new string[] { "YB", "YB", "XB" }, "GayTurn", new float[] { 0f, 0f, .2f});
    private KeyCombo HipHopFlip = new KeyCombo(new string[] { "AB", "AB", "YB" }, "HipHopFlip", new float[] { 0.3f, 0, 0 });
    private KeyCombo Twerk = new KeyCombo(new string[] { "XB", "BB", "XB" }, "Twerk", new float[] { 0, 0.2f, 0.1f });
    private KeyCombo Gangnam = new KeyCombo(new string[] { "AB", "YB", "XB" }, "Gangnam", new float[] { 0, 0, 0.2f });
    private KeyCombo Thriller = new KeyCombo(new string[] { "BB", "XB", "YB" }, "Thriller", new float[] { 0, 0.2f, 0 });

    private bool udoAlive = true;
    private float camDistance = 6;
    private bool isDancing = false;
    private bool isSupermove = false;
    private float time = 0;

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



        // CHECK FOR SUPERMOVE STATE
        if (!aniTimer.IsName("Free Movement") && udoAlive && !aniTimer.IsName("Jump") && !aniTimer.IsName("Falling") && !aniTimer.IsName("Landing"))
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
