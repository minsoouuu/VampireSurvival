using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnController : MonoBehaviour
{
    float spawnTime = 0;
    [SerializeField] private Enemy[] Enemies;
    [SerializeField] private Transform itemparent;
    [SerializeField] private Transform[] enemySpawnPoints;
    int spawnIndex = 0;
    int enemyCount = 0;


    void Update()
    {
        if (GameManager.instance.isLive == false)
        {
            return;
        }
        
        spawnTime += Time.deltaTime;
        if (spawnTime > 1f)
        {
            CreateEnemy(spawnIndex);
            spawnTime = 0f;
            enemyCount++;
        }
        if (enemyCount > 10)
        {
            spawnIndex++;
            enemyCount = 0;
        }
        if (spawnIndex > 4)
        {
            spawnIndex = 0;
        }
    }
    void CreateEnemy(int index)
    {
        for (int i = 0; i < enemySpawnPoints.Length; i++)
        {
            Enemy enemy = Instantiate(Enemies[index], enemySpawnPoints[i]);
            enemy.itemParent = this.itemparent;
            enemy.Init();
            GameManager.instance.player.enemys.Add(enemy);
        }
    }
}
