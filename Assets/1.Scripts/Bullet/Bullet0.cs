using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet0 : Bullet
{
    public override void Initalize()
    {
        bulletData.damage = 5f;
        bulletData.speed = 5f;
    }
    private void Start()
    {
        Initalize();
    }
}
