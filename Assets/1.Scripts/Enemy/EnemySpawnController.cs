using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnController : MonoBehaviour
{
    float spawnTime = 0;
    [SerializeField] private Enemy[] Enemies;
    [SerializeField] private Transform trans;
    [SerializeField] private Transform itemtrans;
    [SerializeField] private Transform boxtrans;
    [SerializeField] private Transform spawnPoints;
    [SerializeField] private Transform[] esps;
    int spawnIndex = 0;
    int enemyCount = 0;


    [SerializeField] private GameObject box;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.isLive == false)
        {
            return;
        }
        
        spawnTime += Time.deltaTime;
        if (spawnTime > 1f)
        {
            Test(spawnIndex);
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
    void Test(int index)
    {
        for (int i = 0; i < esps.Length; i++)
        {
            Enemy enemy = Instantiate(Enemies[index], esps[i]);
            enemy.Init();
            enemy.itemParent = itemtrans;
            enemy.boxParent = boxtrans;
            //GameManager.instance.player.transform.GetChild(0).GetComponent<Weapon>().enemys.Add(enemy);
            GameManager.instance.player.enemys.Add(enemy);
            //enemy.transform.SetParent(trans);
        }
    }
    
    void CreateEnemy(int index)
    {
        Enemy enemy = Instantiate(Enemies[index], spawnPoints);
        enemy.Init();
        enemy.itemParent = itemtrans;
        enemy.boxParent = boxtrans;
        //GameManager.instance.player.transform.GetChild(0).GetComponent<Weapon>().enemys.Add(enemy);
        GameManager.instance.player.enemys.Add(enemy);
        //enemy.transform.SetParent(trans);
    }
}
