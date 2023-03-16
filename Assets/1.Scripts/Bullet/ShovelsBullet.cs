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
}
