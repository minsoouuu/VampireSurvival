using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : Enemy
{
    public override void Init()
    {
        enemyData.speed = 3f;
        enemyData.damage = 20f;
        enemyData.hp = 100f;
    }
}
