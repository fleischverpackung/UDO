using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Medicine : Drug
{
    

    public override void drugAnimation()
    {
        Debug.Log("medicin animation");
    }

    public override void setLevels()
    {
        coke = Random.Range(cokeMin, cokeMax);
        mdma = Random.Range(mdmaMin, mdmaMax);
        weed = Random.Range(weedMin, weedMax);
        type = drugType.MEDICINE;
        Debug.Log("medicin values set");
    }

}
