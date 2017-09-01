using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectsControl : MonoBehaviour {

    public ParticleSystem particleFloor;
    //public MeshRenderer videoRenderer;



    // Use this for initialization
    void Start()
    {
        //particleFloor.Play();
        particleFloor.Emit(0);
        //videoRenderer.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (AnimationControl.Instance.GetIsSupermove())
        {

            particleFloor.Emit(2);
            //videoRenderer.enabled = true;
        }
        else
        {
            particleFloor.Emit(0);
           // videoRenderer.enabled = false;
        }

    }
}
