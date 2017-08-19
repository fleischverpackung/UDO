using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Audio : MonoBehaviour {


    UdoPlayer udo;
    AudioClip[] clips;
    public AudioMixer mixer;
    private float killLevel;



    void Start () {

        //Resources.Load("_Audio/heart")
        udo = GameObject.Find("UDO").GetComponent<UdoPlayer>();

        

    }
	


	void Update () {

        killLevel = udo.getKillLevel();

        // FUGLYY

        
        if (killLevel >= 0 && killLevel <= 3)
        {
            mixer.SetFloat("heartSlow", 0);
            mixer.SetFloat("heartFast", -80);
            mixer.SetFloat("heartBounce", -80);
        }

        if (killLevel > 3 && killLevel <= 6)
        {

            mixer.SetFloat("heartSlow", -80);
            mixer.SetFloat("heartFast", 0);
            mixer.SetFloat("heartBounce", -80);
        }
        if (killLevel > 6 && killLevel < 10)
        {
            mixer.SetFloat("heartSlow", -80);
            mixer.SetFloat("heartFast", -80);
            mixer.SetFloat("heartBounce", 0);
        }
        if (killLevel >= 10)
        {
            mixer.SetFloat("heartSlow", -80);
            mixer.SetFloat("heartFast", -80);
            mixer.SetFloat("heartBounce", -80);
        }



            // mixer.SetFloat("heartSlow", ExtensionMethods.Remap(killLevel, 0, -80, 1, 2));
            //mixer.SetFloat("heartFast", Remap(killLevel, 0, -80, 1, 2)); 
            Debug.Log(killLevel);
    }

    

}

    public static class ExtensionMethods
    {

        public static float Remap(this float value, float from1, float to1, float from2, float to2)
        {
            return (value - from1) / (to1 - from1) * (to2 - from2) + from2;
        }

    }


