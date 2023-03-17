using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Machinegun : Weapon
{
    float time = 0f;
    bool ison = true;
    private void Start()
    {
        Initailize();
    }
    public override void Initailize()
    {
        weapons.damage = 2f;
        weapons.dis = 8f;
        weapons.shotDelay = 0.5f;
    }
    public override void Attack()
    {
        if (!ison)
            return;
        time += Time.deltaTime;
        if (time > weapons.shotDelay)
        {
            StartCoroutine(Shot(weapons.shotDelay,5));
            time = 0f;
            ison = false;
        }
    }

    IEnumerator Shot(float delay,int count)
    {
        for (int i = 0; i < count; i++)
        {
            Bullet bull = Instantiate(bullet, GameManager.instance.player.bulletpos);
            bull.transform.SetParent(GameManager.instance.player.bulletparent);
            yield return new WaitForSeconds(0.1f);
        }
        yield return new WaitForSecondsRealtime(0.1f);
        ison = true;
    }
}
