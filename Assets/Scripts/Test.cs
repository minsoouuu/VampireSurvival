using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField] Player player;
    Queue<GameObject> maps = new Queue<GameObject>();
    [SerializeField] private GameObject map;
    void Start()
    {
        
    }

    void Update()
    {

    }
    


    void CreateMap()
    {
        if (maps != null)
        {
            GameObject nextMap = maps.Dequeue();
            nextMap.SetActive(true);
            Instantiate(nextMap, player.transform);
        }
        else
        {
            maps.Enqueue(map);
            CreateMap();
        }
    }

    void DeleteMap(GameObject map)
    {
        map.SetActive(false);
        maps.Enqueue(map);
    }

}
