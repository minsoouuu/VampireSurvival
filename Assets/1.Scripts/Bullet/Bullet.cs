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

    private void Update()
    {
        //transform.Translate(dir.normalized* Time.deltaTime * bulletData.speed);
        transform.Translate(Vector3.up * Time.deltaTime * bulletData.speed);
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Enemy"))
        {
            collision.GetComponent<Enemy>().HP -= bulletData.damage;
            Debug.Log(collision.gameObject.GetComponent<Enemy>().HP);
            if (collision != null)
            {
                Destroy(gameObject);
            }
        }
    }

    public void SetDir(Quaternion dir )
    {
        transform.rotation = dir;
        //Quaternion qqq = Quaternion.Euler(dir);
    }
}
