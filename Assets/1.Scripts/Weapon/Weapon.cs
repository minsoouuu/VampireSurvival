using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public WeaponData weaponData;

    List<Enemy> enemys = new List<Enemy>();
    Transform bullettrans;
    Enemy target = null;
    float time = 0f;
    private void Update()
    {
        time += Time.deltaTime;
        if (weaponData.ShotDelay < time)
        {
            FindTarget();
        }
    }
    void FindTarget()
    {
        if (enemys.Count != 0)
        {
            foreach (var enemy in enemys)
            {
                if (target == null)
                {
                    target = enemy;
                }
                else
                {
                    float dis = Vector3.Distance(transform.position, target.transform.position);
                    float enemydis = Vector3.Distance(transform.position, enemy.transform.position);

                    if (dis > enemydis)
                    {
                        target = enemy;
                    }
                }
            }
        }
        Attack(target , weaponData , bullettrans);
    }
    public abstract void Attack(Enemy enemy , WeaponData weaponData , Transform trans);

}
