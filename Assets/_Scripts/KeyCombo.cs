using UnityEngine;
using System.Collections;

public class KeyCombo
{
    public string[] buttons;
    private float[] costs;
    private string ani;
    private int currentIndex = 0; //moves along the array as buttons are pressed



    public float allowedTimeBetweenButtons = 0.3f; //tweak as needed
    private float timeLastButtonPressed;



    // EXTERNAL CALL METHOD

    public KeyCombo(string[] b, string a, float[] c)
    {
        ani = a;
        buttons = b;
        costs = c;
    }

    public string GetName()
    {
        return ani;
    }
   

    //usage: call this once a frame. when the combo has been completed, it will return true
    public void Check()
    {
        if (Time.time > timeLastButtonPressed + allowedTimeBetweenButtons) currentIndex = 0;
        {
            if (currentIndex < buttons.Length)
            {
                if (
                (buttons[currentIndex] == "AB" && Input.GetButton("AB")) ||
                (buttons[currentIndex] == "BB" && Input.GetButton("BB")) ||
                (buttons[currentIndex] == "XB" && Input.GetButton("XB")) ||
                (buttons[currentIndex] == "YB" && Input.GetButton("YB")) ||
                (buttons[currentIndex] != "AB" && buttons[currentIndex] != "BB" && buttons[currentIndex] != "XB" && buttons[currentIndex] != "YB" && Input.GetButton(buttons[currentIndex])
                ))
                {
                    timeLastButtonPressed = Time.time;
                    currentIndex++;
                }

                if (currentIndex >= buttons.Length)
                {
                    currentIndex = 0;
                    UdoPlayer.Instance.PaySupermove(costs);
                    AnimationControl.Instance.PlayAni(ani);
                    AnimationControl.Instance.StartCoroutine();
                    //return true;
                }
                //else return false;
            }
        }

        //return false;

        
      

    }


}
