using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Weapons
{
    public float damage;
    public float shotDelay;
    public float dis;
}
public abstract class Weapon : MonoBehaviour
{
    public Weapons weapons = new Weapons();
    public Bullet bullet;
    public Enemy target;
    float time = 0;
    public abstract void Initailize();
    public abstract void Attack();

    private void Update()
    {
        time += Time.deltaTime;
        float dis = Vector3.Distance(transform.position, target.transform.position);
        if (target == null)
        {
            return;
        }
        if (dis <= weapons.dis)
        {
            if (time > weapons.shotDelay)
            {
                Attack();
                time = 0f;
            }
        }
    }
}
