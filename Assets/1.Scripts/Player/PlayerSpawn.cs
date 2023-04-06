using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    [SerializeField] private Item exp;
    [SerializeField] private Item mag;
    [SerializeField] private Transform itemParent;
    void Awake()
    {
        Player player = Instantiate(GameManager.instance.player, transform);
        GameManager.instance.player = player;

        
        for (int i = 0; i < 5; i++)
        {
            int rand = Random.Range(0, 15);
            Item expItem = Instantiate(exp,itemParent);
            expItem.transform.SetParent(itemParent);
            expItem.transform.position = new Vector3(rand, rand, 0);
        }
        Item magitem = Instantiate(mag, player.transform);
        magitem.transform.SetParent(itemParent);
    }
}
