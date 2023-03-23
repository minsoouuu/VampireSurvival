using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hoe : Weapon
{
    [SerializeField] private GameObject hoedir;
    float time = 0f;
   
    public override void Initailize()
    {
        weapons.damage = 15f;
        weapons.dis = 10f;
        weapons.shotDelay = 4f;
    }
    public override void Attack()
    {
        time += Time.deltaTime;
        if (time > weapons.shotDelay && ison)
        {
            StartCoroutine(Shot(WeaponLV));
            time = 0f;
            ison = false;
        }
    }
    IEnumerator Shot(int count)
    {
        for (int i = 0; i < count; i++)
        {
            Bullet bull = Instantiate(bullet, GameManager.instance.player.transform);
            bull.transform.SetParent(GameManager.instance.player.bulletparent);
            bull.WeaponDamage = weapons.damage;
            yield return new WaitForSeconds(0.1f);
        }
        yield return new WaitForSeconds(weapons.shotDelay);
        ison = true;
    }
}
