using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EXP1 : Item
{
    public override void GetItem()
    {
        GameManager.instance.player.Exp += itemData.exp;
    }

    public override void Initalize()
    {
        itemData.exp = 20f;
    }

    void Start()
    {
        Initalize();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
