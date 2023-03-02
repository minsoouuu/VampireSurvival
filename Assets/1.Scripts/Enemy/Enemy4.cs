using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy4 : Enemy
{
    public override void Init()
    {
        enemyData.speed = 4;
        enemyData.damage = 25f;
        enemyData.hp = 200f;
    }
}
