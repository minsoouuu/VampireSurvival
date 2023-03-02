using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EXP2 : Item
{
    public override void Initalize()
    {
        itemData.exp = 30f;
    }

    // Start is called before the first frame update
    void Start()
    {
        Initalize();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
