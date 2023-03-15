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
    public abstract void Initailize();
    public abstract void Attack();

    private void Update()
    {
        if (!GameManager.instance.isLive)
            return;
        Attack();
    }
}
