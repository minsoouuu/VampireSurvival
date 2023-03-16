using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Plough : Weapon
{
    List<Enemy> enemies = new List<Enemy>();
    List<Enemy> targets = new List<Enemy>();
    float time = 0f;
    Vector3 vec = new Vector3(0, 2, 0);
    public override void Initailize()
    {
        weapons.damage = 10f;
        weapons.shotDelay = 5f;
        weapons.dis = 2f;
    }
    void Start()
    {
        Initailize();
    }
    public override void Attack()
    {
        if (enemies == null)
            return;
        enemies = GameManager.instance.player.enemys.ToList();
        time += Time.deltaTime;
        
        if (time > weapons.shotDelay)
        {
            float shotDis = weapons.dis;
            foreach (var target in enemies)
            {
                float enemydis = Vector3.Distance(GameManager.instance.player.transform.position, target.transform.position);
                if (shotDis > enemydis)
                {
                    targets.Add(target);
                }
            }
            if (targets.Count > 0)
            {
                List<Enemy> attackOders = new List<Enemy>();
                int attackCnt = 5;
                for (int i = 0; i < attackCnt; i++)
                {
                    int rand = Random.Range(0, targets.Count);
                    attackOders.Add(targets[rand]);
                }
                StartCoroutine(CreateWeapon(attackOders));
                time = 0f;
            }
        }
    }
    IEnumerator CreateWeapon(List<Enemy> targets)
    {
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
        }
    }
}
