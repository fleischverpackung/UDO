using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cocain : Drug {


    public override void drugAnimation()
    {
        speed = -100000;
        Debug.Log("speed animation");
    }

    public override void setLevels()
    {
        speed = Random.Range(20, 100);
        creativity = Random.Range(-50, -10);
        love = Random.Range(-10, 20);
        type = drugType.COCAIN;
        Debug.Log("speed values set");
    }
    
}
