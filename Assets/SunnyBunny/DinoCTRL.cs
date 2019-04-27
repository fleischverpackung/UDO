using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinoCTRL : MonoBehaviour
{

    Vector3 targetPosition;
    Vector3 lookAtTarget;
    Quaternion playerRot;
    float rotSpeed = 3;
    float speed = 8;
    bool moving = false;
    public Animator anim;
    float gravity = 10;
    int Walk;
    public float Wave;

    // Start is called before the first frame update
    void Start()
    {
        // anim = GetComponentInChildren<Animator>();
        anim = this.gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        Wave = Input.GetAxis("Vertical");
        anim.SetFloat("Wave", Wave);
        if (Input.GetMouseButton(0))
        {
            SetTargetPosition();
        }
        if (moving)
        {
            Move();
        }
        /*
        if (Input.GetButtonDown("Jump") && moving == false)
        {


            anim.SetInteger("condition", 2);


        }

        else {
            anim.SetInteger("condition", 0);
        }

    */


    }


    void SetTargetPosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        int layer_mask = LayerMask.GetMask("Terrain");

        if (Physics.Raycast(ray, out hit, 1000, layer_mask))
        {
            targetPosition = hit.point;
            //this.transform.LookAt(targetPosition);
            lookAtTarget = new Vector3(targetPosition.x - transform.position.x,
                transform.position.y,
                targetPosition.z - transform.position.z);
            playerRot = Quaternion.LookRotation(lookAtTarget);
            moving = true;
            // anim.SetInteger("condition", 1);

            anim.SetInteger("Walk", 1);

        }


    }


    void Move()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation,
                                                playerRot,
                                                rotSpeed * Time.deltaTime);
        transform.position = Vector3.MoveTowards(transform.position,
                                                    targetPosition,
                                                    speed * Time.deltaTime);

        float dist = Vector3.Distance(transform.position, targetPosition);

        if (dist < 5)
        {
            moving = false;
            anim.SetInteger("Walk", 0);

    

       
   
        }


    }

}
