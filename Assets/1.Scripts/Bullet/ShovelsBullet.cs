using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShovelsBullet : Bullet
{
    public override void Initalize()
    {
        bulletData.damage = 5f;
        bulletData.speed = 3f;
    }

    // Start is called before the first frame update
    void Start()
    {
        Initalize();
    }

    public override void Attack()
    {
        float dir = 0;
        dir += Time.deltaTime * bulletData.speed;
        transform.parent.transform.eulerAngles += new Vector3(0, 0, 1);
    }

    public override void Hit(Collider2D coll)
    {
        Vector3 dis = coll.transform.position - GameManager.instance.player.transform.position;
        Vector3 dir = Vector3.Normalize(dis);
        if (coll.gameObject.CompareTag("Enemy"))
        {
            Enemy enemy = coll.GetComponent<Enemy>();
            enemy.HP -= bulletData.damage;
            enemy.transform.Translate(dir * 0.2f);
        }
    }

    IEnumerator KnockBackEnemy(float enemyX,bool isRight)
    {
        for (int i = 0; i < 5; i++)
        {
       
            yield return new WaitForSeconds(0.1f);
        }
    }
}
