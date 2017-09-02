using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.Events;
using UnityEngine.UI;

public class Gui : MonoBehaviour
{
    public static Gui Instance { get; private set; }

    public Slider sliderCoke;
    public Slider sliderMdma;
    public Slider sliderWeed;
    public Slider sliderCokeDiff;
    public Slider sliderMdmaDiff;
    public Slider sliderWeedDiff;
    public Text multi;
    public Text points;
    public Text supermove;
    public Text lowEnergy;
    public Text bonusPointsTxt;
    public Light licht;
    //private ParticleSystem particleFloor;
    //public RenderSettings renderSettings;
    //public Material skyA;
    //public Material skyB;
    private string supermoveName;
    private int bonuspoints;

    

    private void Awake()
    {
        supermove.enabled = false;
        lowEnergy.enabled = false;
        bonusPointsTxt.enabled = false;
        licht.enabled = false;

        //particleFloor = GameObject.Find("UDO").GetComponentInChildren<ParticleSystem>();

        //particleFloor.Play();
        //particleFloor.Emit(0);

        if (Instance != null)
        {
            DestroyImmediate(gameObject);
            return;
        }
        Instance = this;

    }

    private void Update()
    {


        if (UdoPlayer.Instance != null)
        {
            sliderCoke.value = UdoPlayer.Instance.GetCoke();
            sliderMdma.value = UdoPlayer.Instance.GetMdma();
            sliderWeed.value = UdoPlayer.Instance.GetWeed();
            multi.text = "x " + Mathf.Round(UdoPlayer.Instance.GetToxicationBonus() * 3).ToString();
            points.text = UdoPlayer.Instance.GetScore().ToString();
            sliderCokeDiff.value = UdoPlayer.Instance.GetStatsOld().x;
            sliderMdmaDiff.value = UdoPlayer.Instance.GetStatsOld().y;
            sliderWeedDiff.value = UdoPlayer.Instance.GetStatsOld().z;
        }


        if (AnimationControl.Instance.GetIsSupermove())
        {
            supermove.text = "COMBOMOVE: " + supermoveName;
            supermove.enabled = true;
            licht.enabled = true;
            //particleFloor.Emit(1);
            UdoPlayer.Instance.SetParticleFloor(true);

        }
        else
        { 
            supermove.enabled = false;
            licht.enabled = false;

            //particleFloor.Emit(0);
            UdoPlayer.Instance.SetParticleFloor(false);
        }
        

        

     }

    private void ShowDeathInfo()
    {
        // removed deathImage
    }

    public void SetComboName(string x)
    {
        supermoveName = x;
    }

    public void BlinkLowEnergy()
    {
        StartCoroutine(LowEnergy());
    }

    IEnumerator StatsDifference()
    {

        yield return new WaitForSeconds(3);
    }


     IEnumerator LowEnergy()
    {
        for (int i = 0; i < 3; i++)
        {
            lowEnergy.enabled = true;
            yield return new WaitForSeconds(.3f);
            lowEnergy.enabled = false;
            yield return new WaitForSeconds(.3f);
        }
        
    }

    IEnumerator BonusPoints()
    {
        bonusPointsTxt.enabled = true;
        yield return new WaitForSeconds(3);
        bonusPointsTxt.enabled = false;
    }
    public void SetBonusPoints(int x)
    {        
        bonusPointsTxt.text = "+ " + x + "PTS";
        StartCoroutine(BonusPoints());
    }
}

