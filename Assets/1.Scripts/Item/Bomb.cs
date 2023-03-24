using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : Item
{
    public override void GetItem(Collider2D collision)
    {
        foreach (var target in GameManager.instance.player.enemys)
        {
            float dis = Vector3.Distance(target.transform.position, GameManager.instance.player.transform.position);
            if (dis < 8)
            {
                //target.GetComponent<Enemy>().HP -= 1000f;
                target.GetComponent<Transform>().localScale = new Vector3(1, 1, 1);
            }
        }
    }
    public override void Initalize()
    {
        itemData.exp = 0.5f;
    }
}
