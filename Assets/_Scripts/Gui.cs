using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Gui : MonoBehaviour
{
    //public static Gui Instance { get; private set; }

    public Slider health;
    public Slider sanity;
    public Slider love;
    public Slider intoxication;
    public Text multi;
    public Text points;

    private UnityAction deathListener;
    public Image deathImg;

    private void Awake()
    {
        /*
        if (Instance != null)
        {
            DestroyImmediate(gameObject);
            return;
        }
        Instance = this;
        */

        deathImg.enabled = false;
        deathListener = new UnityAction(ShowDeathInfo);
    }

    private void Update()
    {

        //health.value =  Mathf.Lerp(0.85f, 1.15f, 0 / 5);
        
        if (UdoPlayer.Instance != null)
        {
            health.value = 1 - UdoPlayer.Instance.getHealth() * 0.1f;
            sanity.value = 1 - UdoPlayer.Instance.getLove() * 0.1f;
            love.value = 1 - UdoPlayer.Instance.getSanity() * 0.1f;    
            intoxication.value = UdoPlayer.Instance.getKillLevel() * 0.1f;
            multi.text = "x " + Mathf.Round(UdoPlayer.Instance.getKillLevel()).ToString();
            points.text = Mathf.Round(Timer.Instance.GetHighscore()).ToString();
        }
        
        
    }

    private void OnEnable()
    {
        EventManager.StartListening("guiDeathScreen", deathListener);
    }

    private void OnDisable()
    {
        EventManager.StopListening("guiDeathScreen", deathListener);
    }

    private void ShowDeathInfo()
    {
        deathImg.enabled = true;
    }

   
}
