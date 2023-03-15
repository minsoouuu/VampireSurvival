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
        GameObject dir = Instantiate(shovelsDir, transform.parent.transform);
        transform.SetParent(dir.transform);
        GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1 / 255f);
        Instantiate(bullet, dir.transform);
    }
    public override void Initailize()
    {
        weapons.damage = 5f;
        weapons.dis = 0f;
    }
    
    public override void Attack()
    {

    }

    void CreateShovels(int count)
    {
        for (int i = 0; i < count; i++)
        {

        }
    }
}
