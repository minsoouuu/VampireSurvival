using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoeBullet : Bullet
{
    bool isBack = false;
    int randDir;
    private void Start()
    {
        Initalize();
    }
    public override void Initalize()
    {
        bulletData.damage = 15f;
        bulletData.speed = 8f;
        randDir = Random.Range(0, 7);
    }
    public override void Attack()
    {
        transform.eulerAngles += new Vector3(0, 0, 1) * 50f;

        float dis = Vector3.Distance(transform.position, GameManager.instance.player.transform.position);
        Vector3 dir = GameManager.instance.player.transform.position - transform.position;


        if (isBack == false)
        {
            Move(randDir);
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
    void Move(int dir1)
    {
        switch (dir1)
        {
            case 0:
                transform.position += new Vector3(1, 0, 0) * Time.deltaTime * bulletData.speed;
                break;
            case 1:
                transform.position += new Vector3(-1, 0, 0) * Time.deltaTime * bulletData.speed;
                break;
            case 2:
                transform.position += new Vector3(0, 1, 0) * Time.deltaTime * bulletData.speed;
                break;
            case 3:
                transform.position += new Vector3(0, -1, 0) * Time.deltaTime * bulletData.speed;
                break;
            case 4:
                transform.position += new Vector3(1, 1, 0) * Time.deltaTime * bulletData.speed;
                break;
            case 5:
                transform.position += new Vector3(-1, 1, 0) * Time.deltaTime * bulletData.speed;
                break;
            case 6:
                transform.position += new Vector3(-1, -1, 0) * Time.deltaTime * bulletData.speed;
                break;
            case 7:
                transform.position += new Vector3(1, -1, 0) * Time.deltaTime * bulletData.speed;
                break;

        }
        
    }
    public override void Hit(Collider2D coll)
    {
        if (coll.gameObject.CompareTag("Enemy"))
        {
            coll.GetComponent<Enemy>().HP -= Damage();
        }
        else if (coll.gameObject.CompareTag("Player") && isBack == true)
        {
           Destroy(gameObject);
        }
    }
}
