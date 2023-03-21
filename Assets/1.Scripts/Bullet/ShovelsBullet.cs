using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShovelsBullet : Bullet
{
    public override void Initalize()
    {
        bulletData.damage = 5f;
        bulletData.speed = 50f;
    }
    // Start is called before the first frame update
    void Start()
    {
        Initalize();
    }
    public override void Attack()
    {
        transform.parent.transform.rotation *= Quaternion.Euler(new Vector3(0, 0, 1) * Time.deltaTime * bulletData.speed);
        
        //float dir = 0;
        //dir += Time.deltaTime * bulletData.speed;
        //transform.parent.transform.eulerAngles += new Vector3(0, 0, 1) * bulletData.speed;
        
        //물체가 직접 회전
        //Vector3 dis = GameManager.instance.player.transform.position - transform.position;
        //Vector3 offset = Quaternion.AngleAxis(dir,Vector3.forward) * dis;
        //transform.position = GameManager.instance.player.transform.position + offset;
    }

    public override void Hit(Collider2D coll)
    {
        Vector3 dis = coll.transform.position - GameManager.instance.player.transform.position;
        Vector3 dir = Vector3.Normalize(dis);
        if (coll.gameObject.CompareTag("Enemy"))
        {
            Enemy enemy = coll.GetComponent<Enemy>();
            enemy.HP -= bulletData.damage;
            enemy.transform.Translate(dir * 0.1f);
        }
    }
}
