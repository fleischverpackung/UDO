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
        health = Random.Range(healthMin, healthMax);
        sanity = Random.Range(sanityMin, sanityMax);
        love = Random.Range(loveMin, loveMax);
        type = drugType.WEED;
        Debug.Log("weed values set");
    }

}
