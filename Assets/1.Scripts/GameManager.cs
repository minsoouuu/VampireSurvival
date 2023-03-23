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
    void Awake()
    {
        instance = this;
    }
}
