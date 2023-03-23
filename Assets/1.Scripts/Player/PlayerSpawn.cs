using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    void Awake()
    {
        Player player = Instantiate(GameManager.instance.player, transform);
        GameManager.instance.player = player;
    }
}
