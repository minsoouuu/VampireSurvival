using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : Enemy
{
    public override void Init()
    {
        enemyData.speed = 2f;
        enemyData.damage = 10f;
        enemyData.hp = 100f;
    }
    
}
