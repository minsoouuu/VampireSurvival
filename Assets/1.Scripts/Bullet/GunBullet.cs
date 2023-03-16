using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBullet : Bullet
{
    public override void Initalize()
    {
        bulletData.damage = 10f;
        bulletData.speed = 5f;
    }
    private void Start()
    {
        Initalize();
    }
    public override void Attack()
    {
        transform.Translate(Vector3.up * Time.deltaTime * bulletData.speed);
    }
}
