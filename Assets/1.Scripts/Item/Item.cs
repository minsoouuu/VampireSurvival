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

    public virtual void GetMagItem()
    {
        StartCoroutine("ItemMove");
    }
    IEnumerator ItemMove()
    {
        yield return new WaitForSeconds(0.1f);

        while (gameObject != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, GameManager.instance.player.transform.position, 0.1f);
            yield return new WaitForSeconds(0.01f);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            GetItem();
            Destroy(gameObject);
        }
    }
}
