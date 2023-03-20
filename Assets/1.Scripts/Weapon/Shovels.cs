using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shovels : Weapon
{
    [SerializeField] private GameObject shovelsDir;
    // Start is called before the first frame update
    void Start()
    {
        Initailize();
        GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1 / 255f);
    }
    public override void Initailize()
    {
        weapons.damage = 5f;
        weapons.dis = 0f;
    }
    
    public override void Attack()
    {
        if (Input.GetKeyDown(KeyCode.F3))
        {
            CreateShovels(WeaponLV);
        }
    }

    void CreateShovels(int count)
    {
        int child = transform.childCount;
        if (transform.childCount > 0)
        {
            for (int i = 0; i < child; i++)
            {
                Destroy(transform.GetChild(i));
            }
        }
        return;
        Vector3 vec = new Vector3(0, 1.5f, 0);
        int ea = count / 360;
        for (int i = 0; i <= count; i+= ea)
        {
            Bullet bull = Instantiate(bullet, transform);
            bull.transform.position += vec;
            bull.transform.eulerAngles += new Vector3(0, 0, i);
            bull.transform.SetParent(GameManager.instance.player.bulletparent);
        }
    }
}
