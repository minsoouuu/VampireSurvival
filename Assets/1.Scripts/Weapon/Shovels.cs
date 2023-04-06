using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shovels : Weapon
{
    [SerializeField] private GameObject shovelsDir;
    
    public override void Initailize()
    {
        weapons.damage = 50f;
        weapons.dis = 0f;
    }
    
    public override void Attack()
    {
        if (!ison)
        {
            return;
        }
        Debug.Log(WeaponLV);
        Create(WeaponLV);
    }
    void Create(int count)
    {
        int child = transform.childCount;
        if (child > 0)
        {
            for (int i = 0; i < child; i++)
            {
                Destroy(transform.GetChild(i).gameObject);
            }
        }

        float createDir = 360 / count;
        Vector3 dir = (transform.position + new Vector3(0, 1.5f, 0)) - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        for (float i = 0; i < 360; i += createDir)
        {
            Bullet bull = Instantiate(bullet, transform);
            transform.rotation = Quaternion.AngleAxis((angle - 90) + i, Vector3.forward);
            bull.transform.rotation = Quaternion.AngleAxis((angle - 90), Vector3.forward);
            bull.transform.position += new Vector3(0, 1.5f, 0);
            bull.WeaponDamage = weapons.damage;

        }
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        ison = false;
    }
}
