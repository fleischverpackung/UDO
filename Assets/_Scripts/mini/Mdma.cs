using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mdma : Drug
{

    // Hey ladies and gents,
    // this is just a funny computer game.

    public override void drugAnimation()
    {
        weed = +100000;
        Debug.Log("mdma animation");
    }

    public override void setLevels()
    {
        coke = Random.Range(cokeMin, cokeMax);
        mdma = Random.Range(mdmaMin, mdmaMax);
        weed = Random.Range(weedMin, weedMax);
        type = drugType.MDMA;
        Debug.Log("mdma values set");
    }

}
