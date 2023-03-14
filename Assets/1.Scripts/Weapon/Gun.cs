using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : Weapon
{
    public override void Initailize()
    {
        weapons.damage = 50f;
        weapons.shotDelay = 2f;
        weapons.dis = 10f;
    }
    public override void Attack()
    {
       
        Vector3 dir = target.transform.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        GameManager.instance.player.bulletpos.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        
        Bullet bt = Instantiate(bullet,GameManager.instance.player.bulletpos);
        bt.transform.SetParent(GameManager.instance.player.bulletparent);
    }
}
