using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MDMA : Drug
{

    // Hey ladies and gents,
    // this is just a funny computer game.

    public override void drugAnimation()
    {
        love = +100000;
        Debug.Log("mdma animation");
    }

    public override void setLevels()
    {
        speed = Random.Range(-70, -10);
        creativity = Random.Range(-20, 10);
        love = Random.Range(30, 100);
        type = drugType.MDMA;
        Debug.Log("mdma values set");
    }

}
