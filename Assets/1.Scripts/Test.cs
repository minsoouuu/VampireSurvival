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

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag != "Area")
        {
            return;
        }
        Vector3 playerPos = GameManager.instance.player.transform.position;
        Vector3 mapPos = GameManager.instance.player.transform.position;

        float disX = Mathf.Abs(playerPos.x - mapPos.x);
        float disY = Mathf.Abs(playerPos.y - mapPos.y);

        float dirX = GameManager.instance.player.x < 0 ? -1 : 1;
        float dirY = GameManager.instance.player.y < 0 ? -1 : 1;

        if (disX > disY)
        {
            CreateMap(dirX);
        }

    }

    void CreateMap(float dir)
    {
        if (maps != null)
        {
            GameObject nextMap = maps.Dequeue();
            nextMap.SetActive(true);
            
            Instantiate(nextMap,transform);
        }
        else
        {
            maps.Enqueue(map);
            CreateMap(dir);
        }
    }

    void DeleteMap(GameObject map)
    {
        map.SetActive(false);
        maps.Enqueue(map);
    }

}
