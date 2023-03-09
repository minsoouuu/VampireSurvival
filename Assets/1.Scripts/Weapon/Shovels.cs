using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shovels : Weapon
{
    public override void Attack(Enemy target , WeaponData weapon, Transform trans)
    {
        float dis = Vector3.Distance(transform.position, target.transform.position);

        if (dis < 10)
        {
            Vector3 dir = target.transform.position - transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);

            Weapon bt = Instantiate(weapon.Weapon, transform);
            bt.transform.SetParent(trans);
        }
    }
}
