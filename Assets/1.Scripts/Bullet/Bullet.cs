using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct BulletData
{
    public float damage;
    public float speed;
}

public abstract class Bullet : MonoBehaviour
{

    public float WeaponDamage { get; set; }

    public BulletData bulletData = new BulletData();
    public abstract void Initalize();
    private void FixedUpdate()
    {
        if (!GameManager.instance.isLive)
            return;
        Attack();
    }
    public abstract void Attack();
    public abstract void Hit(Collider2D coll);
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Hit(collision);
    }

    public float Damage()
    {
        float damage = bulletData.damage + GameManager.instance.player.Damage + WeaponDamage;
        return damage;
    }
}
