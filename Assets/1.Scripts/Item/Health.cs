using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : Item
{
    public override void Initalize()
    {
        itemData.exp = 0.5f;
        itemData.health = 50f;
    }
    public override void GetItem(Collider2D collision)
    {
        collision.GetComponent<Player>().HP += 50f;
    }
}
