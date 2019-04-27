using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eyeblink : MonoBehaviour
{
    
    public float blinkEyeRate;
    public float blinkCloseRate;
    private float previousBlinkEyeRate;
    private float closeEyeTime;
    private Vector3 min = new Vector3(0.1f, 0.1f, 0.1f);
    private Vector3 max = new Vector3(1f, 1f, 1f);
    private SkinnedMeshRenderer l_eye_renderer;
    private SkinnedMeshRenderer r_eye_renderer;
    private GameObject l_eye;
    private GameObject r_eye;


    private void Start()
    {
        l_eye = GameObject.Find("geo_l_eye");
        r_eye = GameObject.Find("geo_r_eye");
        l_eye_renderer = l_eye.GetComponent<SkinnedMeshRenderer>();
        r_eye_renderer = r_eye.GetComponent<SkinnedMeshRenderer>();
    }
    void Update()
    {        
        if (Time.time > closeEyeTime)
        {    
            previousBlinkEyeRate = blinkEyeRate;
            closeEyeTime = Time.time + blinkEyeRate;
            StartCoroutine(Blink());
            while (previousBlinkEyeRate == blinkEyeRate)
            {                
                blinkEyeRate = Random.Range(4f, 10f); 
            }            
        }     
    }

    IEnumerator Blink()
    {
        EyesScale(min);
        EyesRenderer(false);
        yield return new WaitForSeconds(blinkCloseRate);
        EyesRenderer(true);
        EyesScale(max);
    }

    void EyesScale(Vector3 x)
    {
        r_eye.transform.localScale = x;
        l_eye.transform.localScale = x;
    }

    void EyesRenderer(bool x)
    {
        r_eye_renderer.enabled = x;
        l_eye_renderer.enabled = x;
    }


}



