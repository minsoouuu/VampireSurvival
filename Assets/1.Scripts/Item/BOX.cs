using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BOX : Item
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    public override void Initalize()
    {

    }
    public override void GetItem()
    {
        GameObject items = GameObject.Find("ItemParent");

        int itemEa = items.transform.childCount;

        for (int i = 0; i < itemEa; i++)
        {
            StartCoroutine(ItemMove(items.transform.GetChild(i).gameObject));
        }
    }

    IEnumerator ItemMove(GameObject item)
    {
        yield return new WaitForSeconds(0.5f);

        while (item != null)
        {
            item.transform.position = Vector3.MoveTowards(item.transform.position, GameManager.instance.player.transform.position, Time.deltaTime);
            yield return new WaitForSeconds(0.1f);
        }
    }
}
