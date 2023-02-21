using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class MapController : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private List<GameObject> maps;

    float playerXpos;
    float playerYpos;
    void Start()
    {

    }
    void Update()
    {
        if (player.transform.position.x % 10 == 0)
        {
            if (player.transform.position.x > 10)
            {
                maps[0].transform.position = new Vector3(30, 10, 0);
                maps[2].transform.position = new Vector3(30, -10, 0);
            }
            else if (player.transform.position.x < -10)
            {
                maps[1].transform.position = new Vector3(30, 10, 0);
                maps[3].transform.position = new Vector3(30, -10, 0);
            }
        }
        else if (player.transform.position.y % 10 == 0)
        {
            if (player.transform.position.y > 10)
            {
                maps[2].transform.position = new Vector3();
                maps[3].transform.position = new Vector3();
            }
            else if (player.transform.position.y < -10)
            {
                maps[0].transform.position = new Vector3();
                maps[1].transform.position = new Vector3();
            }
        }
    }
}
