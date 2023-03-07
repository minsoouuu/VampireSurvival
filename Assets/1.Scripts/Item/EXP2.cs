using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EXP2 : Item
{
    public override void Initalize()
    {
        itemData.exp = 30f;
    }

   
    void Start()
    {
        Initalize();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void GetItem()
    {
        GameManager.instance.player.Exp += itemData.exp;
    }
}
