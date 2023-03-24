using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : Item
{
    public override void GetItem(Collider2D collision)
    {
        collision.GetComponent<Player>().Damage += 10f;
    }

    public override void Initalize()
    {
        itemData.exp = 5f;
    }
}
