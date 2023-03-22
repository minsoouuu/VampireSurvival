using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    public UIController uicont;
    public List<WeaponData> weaponDatas;
    public Player player;
    public bool isLive = false;
    public Transform playerSpawnPoint;
    public Transform bulletParent;
    public List<Player> players = new List<Player>();
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }

        //int rand = Random.Range(0, players.Count);
        //SetPlayer(players[rand]);
    }

    void SetPlayer(Player player)
    {
        Player play = Instantiate(player, playerSpawnPoint);
        isLive = true;
    }
}
