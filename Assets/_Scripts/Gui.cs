using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Gui : MonoBehaviour
{

    private UnityAction deathListener;
    public Image deathImg;

    private void Awake()
    {
        deathImg.enabled = false;
        deathListener = new UnityAction(ShowDeathInfo);
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
