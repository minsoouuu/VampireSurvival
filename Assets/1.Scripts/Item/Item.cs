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

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<Player>().Exp += itemData.exp;
            Destroy(gameObject);
        }
    }

}
