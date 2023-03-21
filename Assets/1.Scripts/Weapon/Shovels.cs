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
            Test(WeaponLV);
        }
    }

    void CreateShovels(int count)
    {
        Vector3 vec = new Vector3(0, 1.5f, 0);
        int ea = count / 360;
        for (int i = 0; i <= count; i+= ea)
        {
            Bullet bull = Instantiate(bullet, transform);
            bull.transform.position += vec;
            bull.transform.eulerAngles += new Vector3(0, 0, i);
        }
    }

    void Test(int count)
    {
        Vector3 vec = new Vector3(0, 1.5f, 0);
        float dir = CalculateAngle(transform.position,GameManager.instance.player.enemys[0].transform.position);
        float ea = count / dir;
        for (float i = 0; i < dir; i += ea)
        {
            Bullet bull = Instantiate(bullet, transform);
            bull.transform.position += vec;
            bull.transform.rotation = Quaternion.Euler(0, 0, i);
        }
    }

    float CalculateAngle(Vector3 from, Vector3 to)
    {
        return Quaternion.FromToRotation(Vector3.up, to - from).eulerAngles.z;
    }
}
