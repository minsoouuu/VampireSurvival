using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BOX : Item
{
    public override void Initalize()
    {
        itemData.exp = 10f;
    }
    public override void GetItem()
    {
        GameObject items = GameObject.Find("ItemParent");
        int itemEa = items.transform.childCount;

        for (int i = 0; i < itemEa; i++)
        {
            items.transform.GetChild(i).GetComponent<Item>().GetMagItem();
        }
    }
}
