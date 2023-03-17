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
    [HideInInspector] public int weponLv = 0;
    public int WeaponLV
    {
        get { return weponLv; }
        set { weponLv = value; }
    }
    public abstract void Initailize();
    public abstract void Attack();
    public void LevelUp()
    {
        weponLv += 12;
    }
    private void Update()
    {
        if (!GameManager.instance.isLive)
            return;
        Attack();
    }
}
