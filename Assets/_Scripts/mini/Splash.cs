using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Splash : MonoBehaviour {

    private Animator animator;
    public Image instructions;
    private string[] motions = { "Entrance", "Warmup", "Spin" };
    public MeshRenderer phone;


    private void Awake()
    {      
        animator = GameObject.Find("UDO").GetComponent<Animator>();
        phone = GameObject.Find("phone").GetComponent<MeshRenderer>();
    }

    void Start () {
        instructions.enabled = false;
        StartCoroutine(Actions());

    }
	


	void Update () {


        AnimatorStateInfo aniTimer = animator.GetCurrentAnimatorStateInfo(0);

        if (aniTimer.IsName("OnMobile"))
            phone.enabled = true;
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
            yield return new WaitForSeconds(15);
            animator.Play(motions[Random.Range(0 ,3)]);
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
