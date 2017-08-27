using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cocain : Drug
{

    public override void drugAnimation()
    {
        //health = -100000;
        //Debug.Log("speed animation");
    }

    public override void setLevels()
    {
        coke = Random.Range(cokeMin, cokeMax);
        mdma = Random.Range(mdmaMin, mdmaMax);
        weed = Random.Range(weedMin, weedMax);
        type = drugType.COCAIN;
        //Debug.Log("speed values set");
    }
    
}
