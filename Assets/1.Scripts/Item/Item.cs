using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public struct ItemData
{
    public float exp;
}

public abstract class Item : MonoBehaviour
{
    public ItemData itemData = new ItemData();

    public abstract void Initalize();

    public abstract void GetItem();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            GetItem();
        }
    }
}
