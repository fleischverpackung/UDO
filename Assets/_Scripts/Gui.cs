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
    

    private void Awake()
    {
        deathImg.enabled = false;
    }

    private void Update()
    {
        
        
        if (UdoPlayer.Instance != null)
        {
            sliderCoke.value = UdoPlayer.Instance.GetCoke();
            sliderMdma.value = UdoPlayer.Instance.GetWeed();
            sliderWeed.value = UdoPlayer.Instance.GetMdma();    
            multi.text = "x " + Mathf.Round(UdoPlayer.Instance.GetToxicationBonus() * 3 ).ToString();
            points.text = UdoPlayer.Instance.GetScore().ToString();
        }
        
        
    }
   

    private void ShowDeathInfo()
    {
        deathImg.enabled = true;
    }
    

   
}
