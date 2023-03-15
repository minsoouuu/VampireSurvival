using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : Weapon
{
    private void Start()
    {
        Initailize();
    }
    public override void Initailize()
    {
        weapons.damage = 50f;
        weapons.shotDelay = 2f;
        weapons.dis = 10f;
    }
    public override void Attack()
    {
        Bullet bt = Instantiate(bullet,GameManager.instance.player.bulletpos);
        bt.transform.SetParent(GameManager.instance.player.bulletparent);
    }
}
