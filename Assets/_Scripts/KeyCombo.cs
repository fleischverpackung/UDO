using UnityEngine;
using System.Collections;

public class KeyCombo
{
    public string[] buttons;
    private float[] costs;
    private string ani;
    private int points;
    private int currentIndex = 0; //moves along the array as buttons are pressed



    public float allowedTimeBetweenButtons = 0.35f; //tweak as needed
    private float timeLastButtonPressed;



    // EXTERNAL CALL METHOD

    public KeyCombo(string[] b, string a, float[] c, int d)
    {
        ani = a;
        buttons = b;
        costs = c;
        points = d;
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
                (buttons[currentIndex] == "AB" && Input.GetButtonDown("AB")) ||
                (buttons[currentIndex] == "BB" && Input.GetButtonDown("BB")) ||
                (buttons[currentIndex] == "XB" && Input.GetButtonDown("XB")) ||
                (buttons[currentIndex] == "YB" && Input.GetButtonDown("YB")) ||
                (buttons[currentIndex] != "AB" && buttons[currentIndex] != "BB" && buttons[currentIndex] != "YB" && buttons[currentIndex] != "XB" && Input.GetButtonDown(buttons[currentIndex])
                ))
                {
                    timeLastButtonPressed = Time.time;
                    currentIndex++;
                }

                if (currentIndex >= buttons.Length)
                {
                    if (UdoPlayer.Instance.CheckCosts(costs))
                    {
                        currentIndex = 0;
                        Gui.Instance.SetComboName(ani);
                        Gui.Instance.SetBonusPoints(points);
                        UdoPlayer.Instance.PaySupermove(costs);
                        UdoPlayer.Instance.SetBonusPoints(points);
                        AnimationControl.Instance.PlayAni(ani);
                        AnimationControl.Instance.StartCoroutine();
                    }
                    else
                    Gui.Instance.BlinkLowEnergy();
                    
                }
            }
        }
    }

}
