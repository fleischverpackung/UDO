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
        speed = Random.Range(-70, -10);
        creativity = Random.Range(-30, 10);
        love = Random.Range(10, 30);
        type = drugType.WEED;
        Debug.Log("weed values set");
    }

}
