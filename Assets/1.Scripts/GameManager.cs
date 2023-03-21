using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public UIController uicont;
    public List<WeaponData> weaponDatas;
    public Player player;
    public bool isLive = false;
    public Transform playerSpawnPoint;
    public List<Player> players = new List<Player>();
    [SerializeField] private Camera came;
    [SerializeField] private Transform bulletParent;
    void Awake()
    {
        instance = this;
        int rand = Random.Range(0, players.Count);
        SetPlayer(players[rand]);
    }

    void SetPlayer(Player player)
    {
        Player play = Instantiate(player, playerSpawnPoint);
        play.bulletparent = this.bulletParent;
        this.player = play;
        isLive = true;
    }
}
