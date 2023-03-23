using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBullet : Bullet
{
    public override void Initalize()
    {
        bulletData.damage = 10f;
        bulletData.speed = 8f;
    }
    private void Start()
    {
        Initalize();
        //Destroy(gameObject, 3f);
    }
    public override void Attack()
    {
        float dis = Vector3.Distance(transform.position, GameManager.instance.player.transform.position);
        if (dis < 10)
        {
            transform.Translate(Vector3.up * Time.deltaTime * bulletData.speed);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public override void Hit(Collider2D coll)
    {
        if (coll.gameObject.CompareTag("Enemy"))
        {
            coll.GetComponent<Enemy>().HP -= (WeaponDamage + bulletData.damage);
        }
    }
}
