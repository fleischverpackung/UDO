using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Gui : MonoBehaviour
{
    //public static Gui Instance { get; private set; }

    public Slider sliderCoke;
    public Slider sliderMdma;
    public Slider sliderWeed;
    //public Slider intoxication;
    public Text multi;
    public Text points;

    //private UnityAction deathListener;
    public Image deathImg;

    public static Gui Instance { get; private set; }

    private void Awake()
    {        
        if (Instance != null)
        {
            DestroyImmediate(gameObject);
            return;
        }
        Instance = this;
        deathImg.enabled = false;
        //deathListener = new UnityAction(ShowDeathInfo);
    }

    private void Update()
    {

        //health.value =  Mathf.Lerp(0.85f, 1.15f, 0 / 5);
        
        if (UdoPlayer.Instance != null)
        {
            sliderCoke.value = UdoPlayer.Instance.GetCoke();
            sliderMdma.value = UdoPlayer.Instance.GetWeed();
            sliderWeed.value = UdoPlayer.Instance.GetMdma();    
            //intoxication.value = UdoPlayer.Instance.GetToxicationBonus();
            multi.text = "x " + Mathf.Round(UdoPlayer.Instance.GetToxicationBonus()).ToString();
            points.text = UdoPlayer.Instance.GetScore().ToString();
        }
        
        
    }
    /*
    private void OnEnable()
    {
        EventManager.StartListening("guiDeathScreen", deathListener);
    }

    private void OnDisable()
    {
        EventManager.StopListening("guiDeathScreen", deathListener);
    }
    */

    private void ShowDeathInfo()
    {
        deathImg.enabled = true;
    }
    

   
}
