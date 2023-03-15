using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : Weapon
{
    float time = 0f;
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
        if (GameManager.instance.player.target == null)
            return;
        time += Time.deltaTime;
        float dis = Vector3.Distance(transform.position, GameManager.instance.player.target.transform.position);
        if (dis < weapons.dis)
        {
            if (time > weapons.shotDelay)
            {
                Bullet bt = Instantiate(bullet, GameManager.instance.player.bulletpos);
                bt.transform.SetParent(GameManager.instance.player.bulletparent);
                time = 0f;
            }
        }
    }
}
