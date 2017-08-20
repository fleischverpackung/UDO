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
        health = Random.Range(healthMin, healthMax);
        sanity = Random.Range(sanityMin, sanityMax);
        love = Random.Range(loveMin, loveMax);
        type = drugType.MEDICINE;
        Debug.Log("medicin values set");
    }

}
