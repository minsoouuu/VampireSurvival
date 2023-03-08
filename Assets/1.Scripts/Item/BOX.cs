using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BOX : Item
{
    List<GameObject> items_ = new List<GameObject>();


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
            StartCoroutine(ItemMove(items.transform.GetChild(i).gameObject));
            items_.Add(items.transform.GetChild(i).gameObject);
        }
    }

    IEnumerator ItemMove(GameObject item)
    {
        yield return new WaitForSeconds(0.5f);

        while (item != null)
        {
            if (!GameManager.instance.isLive)
                yield break;
            item.transform.position = Vector3.MoveTowards(item.transform.position, GameManager.instance.player.transform.position, 0.1f);
            yield return new WaitForSeconds(0.01f);
        }

        yield return new WaitForSeconds(items_.Count * 1f);
        Destroy(gameObject);
    }
}
