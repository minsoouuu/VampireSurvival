using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EXP2 : Item
{
    public override void Initalize()
    {
        itemData.exp = 30f;
    }
    public override void GetItem(Collider2D collision)
    {
        collision.GetComponent<Player>().Exp += itemData.exp;
    }

}
