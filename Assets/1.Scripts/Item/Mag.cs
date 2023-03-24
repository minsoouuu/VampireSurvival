using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mag : Item
{
    public override void Initalize()
    {
        itemData.exp = 0.5f;
    }
    public override void GetItem(Collider2D collision)
    {
        GameObject items = GameObject.Find("ItemParent");
        int itemEa = items.transform.childCount;

        for (int i = 0; i < itemEa; i++)
        {
            items.transform.GetChild(i).GetComponent<Item>().GetMagItem();
        }
    }
}
