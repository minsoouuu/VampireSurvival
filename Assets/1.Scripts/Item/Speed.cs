using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speed : Item
{
    public override void GetItem(Collider2D collision)
    {
        collision.GetComponent<Player>().Speed += itemData.speed;
    }
    public override void Initalize()
    {
        itemData.speed = 0.1f;
        itemData.exp = 0.5f;
    }
}
