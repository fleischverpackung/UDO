using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Gui : MonoBehaviour
{

    public Slider sliderCoke;
    public Slider sliderMdma;
    public Slider sliderWeed;
    public Text multi;
    public Text points;
    public Image deathImg;
    public Text supermove;
    public ParticleSystem particleFloor;
    

    private void Awake()
    {
        deathImg.enabled = false;
        supermove.enabled = false;
        particleFloor.Play();
    }

    private void Update()
    {
        
        
        if (UdoPlayer.Instance != null)
        {
            sliderCoke.value = UdoPlayer.Instance.GetCoke();
            sliderMdma.value = UdoPlayer.Instance.GetMdma();
            sliderWeed.value = UdoPlayer.Instance.GetWeed();    
            multi.text = "x " + Mathf.Round(UdoPlayer.Instance.GetToxicationBonus() * 3 ).ToString();
            points.text = UdoPlayer.Instance.GetScore().ToString();
        }


        if (AnimationControl.Instance.GetIsSupermove())
        {
            //Debug.Log("PARTICLE");
            supermove.enabled = true;
            particleFloor.Play();
        }
        else
            supermove.enabled = false;
            particleFloor.Pause();


    }
   

    private void ShowDeathInfo()
    {
        deathImg.enabled = true;
    }
    

   
}
