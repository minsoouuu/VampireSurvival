using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3 : Enemy
{
    public override void Init()
    {
        enemyData.speed = 4;
        enemyData.damage = 20f;
        enemyData.hp = 200f;
    }
}
