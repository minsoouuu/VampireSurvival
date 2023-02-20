using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] List<GameObject> maps;
    [SerializeField] List<GameObject> collides;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (player.transform.position.x > 10)
        {
            maps[0].transform.position = new Vector3(30, 10, 0);
            maps[2].transform.position = new Vector3(30, -10, 0);
        }
        else if (player.transform.position.x < -10)
        {
            maps[0].transform.position = new Vector3(-30, 10, 0);
            maps[2].transform.position = new Vector3(-30, -10, 0);
        }
    }
}
