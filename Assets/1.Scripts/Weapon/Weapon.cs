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
    [HideInInspector] public bool ison = true;
    int weponLv = 0;
    public int WeaponLV
    {
        get { return weponLv; }
        set 
        {
            weponLv = value; 
            if (GameManager.instance.player.curWeapons.ContainsKey("shovels"))
            {
                GameManager.instance.player.curWeapons["shovels"].ison = true;
            }
        }
    }
    void Start()
    {
        Initailize();
        GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1 / 255f);
    }
    public abstract void Initailize();
    public abstract void Attack();
   
    private void Update()
    {
        if (!GameManager.instance.isLive)
            return;
        if (GameManager.instance.player.enemys == null)
            return;
        Attack();
    }
}
