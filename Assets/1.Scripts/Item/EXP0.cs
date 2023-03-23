using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EXP0 : Item
{
    public override void Initalize()
    {
        itemData.exp = 10f;
    }

    public override void GetItem(Collider2D collision)
    {
        collision.GetComponent<Player>().Exp += itemData.exp;
    }
}
