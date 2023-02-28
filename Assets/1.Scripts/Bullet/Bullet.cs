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
    Vector3 dir;

    public BulletData bulletData = new BulletData();

    public abstract void Initalize();

    private void Update()
    {
        transform.Translate(dir.normalized* Time.deltaTime * bulletData.speed);
        //transform.Translate(Vector3.up * Time.deltaTime * bulletData.speed);
    }

    public void SetDir(Vector3 dir )
    {
        this.dir = dir;
        Quaternion qqq = Quaternion.Euler(dir);
        transform.rotation = qqq;
        Debug.Log(qqq);
    }
}
