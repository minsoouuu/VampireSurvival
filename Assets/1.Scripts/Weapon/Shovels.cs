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
            Shot(WeaponLV);
        }
    }
   
    void Shot(int count)
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
            bull.transform.rotation = Quaternion.AngleAxis((angle - 90) + 1, Vector3.forward);
            bull.transform.position += new Vector3(0, 1.5f, 0);
            //bull.transform.SetParent(GameManager.instance.player.bulletparent);
        }
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
    }
}
