using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hoe : Weapon
{
    [SerializeField] private GameObject hoedir;
    bool ison = true;
    float time = 0f;
    private void Start()
    {
        Initailize();
    }
    public override void Initailize()
    {
        weapons.damage = 15f;
        weapons.dis = 10f;
        weapons.shotDelay = 4f;
    }
    public override void Attack()
    {
        time += Time.deltaTime;
        if (time > weapons.shotDelay)
        {
            //GameObject dirCube = Instantiate(hoedir, transform);
            Bullet bull = Instantiate(bullet, GameManager.instance.player.transform);
            bull.transform.SetParent(GameManager.instance.player.bulletparent);
            //dirCube.transform.SetParent(GameManager.instance.player.bulletparent);
            time = 0f;
        }
        if (ison)
        {
            
        }
        ison = false;
    }
}
