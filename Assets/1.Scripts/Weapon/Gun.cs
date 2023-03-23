using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : Weapon
{
    float time = 0f;
   
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
            if (ison)
            {
                StartCoroutine(Shot(WeaponLV));
                time = 0f;
                ison = false;
            }
        }
    }
    IEnumerator Shot(int count)
    {
        for (int i = 0; i < count; i++)
        {
            Bullet bt = Instantiate(bullet, GameManager.instance.player.bulletpos);
            bt.transform.SetParent(GameManager.instance.player.bulletparent);
            bt.WeaponDamage = weapons.damage;
            yield return new WaitForSeconds(0.2f);
        }
        yield return new WaitForSeconds(weapons.shotDelay);
        ison = true;
    }
}
