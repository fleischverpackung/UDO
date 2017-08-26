using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weed : Drug
{

    // Hey ladies and gents,
    // this is just a funny computer game.

    public override void drugAnimation()
    {
        //love = +100000;
        Debug.Log("weed animation");
    }

    public override void setLevels()
    {
        coke = Random.Range(cokeMin, cokeMax);
        mdma = Random.Range(mdmaMin, mdmaMax);
        weed = Random.Range(weedMin, weedMax);
        type = drugType.WEED;
        Debug.Log("weed values set");
    }

}
