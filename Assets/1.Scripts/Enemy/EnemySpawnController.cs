using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnController : MonoBehaviour
{
    float spawnTime = 0;
    [SerializeField] private Enemy[] Enemies;
    [SerializeField] private Transform spawnPoints;

    int spawnIndex = 0;
    int enemyCount = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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
        Enemy enemy = Instantiate(Enemies[index], spawnPoints);
        enemy.Init();
    }
}
