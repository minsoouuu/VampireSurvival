using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : Weapon
{
    private void Start()
    {
        Initailize();
    }
    public override void Initailize()
    {
        weapons.dis = 4f;
        weapons.damage = 100f;
        weapons.shotDelay = 10f;
    }
    public override void Attack()
    {
        if (ison)
        {
            StartCoroutine(Shot(WeaponLV));
            ison = false;
        }
    }
    IEnumerator Shot(int count)
    {
        float min = transform.rotation.z - 30;
        float max = transform.rotation.z + 30;
        for (int i = 0; i < count; i++)
        {
            for (float j = min; j < max; j += 8.571428571428571f)
            {
                Bullet bull = Instantiate(bullet, GameManager.instance.player.bulletpos);
                bull.transform.SetParent(GameManager.instance.player.bulletparent);
                bull.transform.rotation *= Quaternion.Euler(new Vector3(0, 0, j));
                //bull.transform.eulerAngles += new Vector3(0, 0, j);
                //bull.GetComponent<ShotgunBullet>().SetDis(weapons.dis);
            }
            yield return new WaitForSeconds(0.2f);
        }
        yield return new WaitForSeconds(weapons.shotDelay);
        ison = true;
    }
}
