using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnController : MonoBehaviour
{
    float spawnTime = 0;
    [SerializeField] private Enemy[] Enemies;
    [SerializeField] private Transform spawnPoints;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        spawnTime += Time.deltaTime;
        if (spawnTime > 3f)
        {
            Enemy enemy = Instantiate(Enemies[0], spawnPoints);
            enemy.Init();
            spawnTime = 0f;
        }
    }
}
