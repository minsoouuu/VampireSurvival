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
    public BulletData bulletData = new BulletData();
    public abstract void Initalize();
    private void FixedUpdate()
    {
        Attack();
    }

    public abstract void Attack();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.GetComponent<Enemy>().HP -= bulletData.damage;
            if (collision != null)
            {
                Destroy(gameObject);
            }
        }
    }
}
