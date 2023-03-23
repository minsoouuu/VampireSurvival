using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Plough : Weapon
{
    List<Enemy> enemies = new List<Enemy>();
    public List<Enemy> targets = new List<Enemy>();
    float time = 0f;
    Vector3 vec = new Vector3(0, 2, 0);
    public override void Initailize()
    {
        weapons.damage = 50f;
        weapons.shotDelay = 3f;
        weapons.dis = 6f;
    }
    public override void Attack()
    {
        if (enemies == null)
            return;
        enemies = GameManager.instance.player.enemys.ToList();
        time += Time.deltaTime;

        foreach (var target in enemies)
        {
            float enemydis = Vector3.Distance(GameManager.instance.player.transform.position, target.transform.position);
            if (weapons.dis > enemydis)
            {
                targets.Add(target);
            }
        }
        if (time > weapons.shotDelay)
        {
            if (!ison)
                return;

            if (targets.Count > 0)
            {
                List<Enemy> attackOders = new List<Enemy>();

                for (int i = 0; i < WeaponLV; i++)
                {
                    int rand = Random.Range(0, targets.Count);
                    attackOders.Add(targets[rand]);
                }
                StartCoroutine(Test(attackOders));
                targets.Clear();
            }
            time = 0f;
        }
    }
    IEnumerator Test(List<Enemy> targets)
    {
        ison = false;
        for (int i = 0; i < targets.Count; i++)
        {
            if (targets[i] != null)
            {
                Bullet bull = Instantiate(bullet, targets[i].transform);
                bull.transform.position += vec;
                bull.transform.SetParent(GameManager.instance.player.bulletparent);
                bull.transform.rotation = Quaternion.Euler(0, 0, 180);
                bull.WeaponDamage = weapons.damage;

                yield return new WaitForSeconds(0.2f);
            }
            else
            {
                continue;
            }
        }
        ison = true;
    }

    IEnumerator CreateWeapon(List<Enemy> targets)
    {
        ison = false;
        for (int i = 0; i < targets.Count; i++)
        {
            if (targets[i] != null)
            {
                Bullet bull = Instantiate(bullet, targets[i].transform);
                bull.transform.position += vec;
                bull.transform.SetParent(GameManager.instance.player.bulletparent);
                bull.transform.rotation = Quaternion.Euler(0, 0, 180);
                yield return new WaitForSeconds(0.2f);
            }
            else
            {
                this.targets.Clear();
                yield return null;
                if (this.targets != null)
                {
                    int rand = Random.Range(0, this.targets.Count);
                    Bullet bull = Instantiate(bullet, this.targets[rand].transform);
                    bull.transform.position += vec;
                    bull.transform.SetParent(GameManager.instance.player.bulletparent);
                    bull.transform.rotation = Quaternion.Euler(0, 0, 180);
                    yield return new WaitForSeconds(0.2f);
                }
            }
        }
        ison = true;
    }
}
