using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy0 : Enemy
{
    public override void Init()
    {
        enemyData.speed = 1f;
        enemyData.damage = 5f;
        enemyData.hp = 100f;
    }
}
