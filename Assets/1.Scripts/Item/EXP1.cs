using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EXP1 : Item
{
    public override void Initalize()
    {
        itemData.exp = 20f;
    }
    void Start()
    {
        Initalize();
    }
    public override void GetItem()
    {
        GameManager.instance.player.Exp += itemData.exp;
        Destroy(gameObject);
    }
}
