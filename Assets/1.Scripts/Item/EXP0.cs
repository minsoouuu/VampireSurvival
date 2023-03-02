using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EXP0 : Item
{
    public override void Initalize()
    {
        itemData.exp = 10f;
    }

    // Start is called before the first frame update
    void Start()
    {
        Initalize();
    }
}
