using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cocain : Drug
{

    public override void drugAnimation()
    {
        //health = -100000;
        Debug.Log("speed animation");
    }

    public override void setLevels()
    {
        health = Random.Range(healthMin, healthMax);
        sanity = Random.Range(sanityMin, sanityMax);
        love = Random.Range(loveMin, loveMax);
        type = drugType.COCAIN;
        Debug.Log("speed values set");
    }
    
}
