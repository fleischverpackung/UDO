using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Splash : MonoBehaviour {

    private Animator animator;
    public Image instructions;
    private string[] motions = { "Warmup", "Dizzy", "Whipping", "PrayDown", "Entrance" };
    private MeshRenderer phone;
    private GameObject udoMesh;


    private void Awake()
    {      
        animator = GameObject.Find("UDO").GetComponent<Animator>();
        phone = GameObject.Find("phone").GetComponent<MeshRenderer>();
        udoMesh = GameObject.Find("UDO");
    }

    void Start () {
        instructions.enabled = false;
        StartCoroutine(Actions());

    }
	


	void Update () {


        AnimatorStateInfo aniTimer = animator.GetCurrentAnimatorStateInfo(0);

        if (aniTimer.IsName("OnMobile"))
        {
            phone.enabled = true;
            //mobile.transform.Rotate(transform.rotation.x, transform.rotation.y + 180, transform.rotation.z);
        
     }
           
        else
            phone.enabled = false;

        if (Input.GetButtonDown("Select"))
        {
            instructions.enabled = !instructions.enabled;
            
        }

    }

    // PLAY RANDOM MOVE 
    IEnumerator Actions()
    {
        while (true)
        {            
            yield return new WaitForSeconds(10);
            animator.Play(motions[Random.Range(0 ,4)]);
        }
        
    }

    public void PlayAni(string x)
    {
        animator.Play(x);
    }

    private void OnDestroy()
    {
        StopCoroutine(Actions());
    }
}
