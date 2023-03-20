using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoeBullet : Bullet
{
    bool isBack = false;
    private void Start()
    {
        Initalize();
    }
    public override void Initalize()
    {
        bulletData.damage = 15f;
        bulletData.speed = 8f;
    }
    public override void Attack()
    {
        transform.eulerAngles += new Vector3(0, 0, 1) * 50f;

        float dis = Vector3.Distance(transform.position, GameManager.instance.player.transform.position);
        Vector3 dir = GameManager.instance.player.transform.position - transform.position;


        if (isBack == false)
        {
            transform.position += new Vector3(1, 0, 0) * Time.deltaTime * bulletData.speed;
            if (dis > 10)
            {
                isBack = true;
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, GameManager.instance.player.transform.position, bulletData.speed * Time.deltaTime);
        }
    }
    public override void Hit(Collider2D coll)
    {
        if (coll.gameObject.CompareTag("Enemy"))
        {
            coll.GetComponent<Enemy>().HP -= bulletData.damage;
        }
        else if (coll.gameObject.CompareTag("Player") && isBack == true)
        {
           Destroy(gameObject);
        }
    }
}
