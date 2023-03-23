using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunBullet : Bullet
{
    float dis;
    private void Start()
    {
        Initalize();
    }
    public override void Initalize()
    {
        bulletData.damage = 30f;
        bulletData.speed = 15f;
    }
    public override void Attack()
    {
        transform.Translate(Vector3.forward * bulletData.speed * Time.deltaTime);
        float curdis = Vector3.Distance(transform.position, GameManager.instance.player.transform.position);
        if (curdis > dis)
        {

        }
    }

    public void SetDis(float dis)
    {
        this.dis = dis;
    }
    public override void Hit(Collider2D coll)
    {
        if (coll.gameObject.CompareTag("Enemy"))
        {
            coll.GetComponent<Enemy>().HP -= (WeaponDamage + bulletData.damage);
            Destroy(gameObject);
        }
    }
}
