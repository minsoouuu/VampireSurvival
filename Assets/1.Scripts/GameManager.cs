using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public UIController uicont;
    public List<WeaponData> weaponDatas;
    public Player player;
    public bool isLive = true;
    void Awake()
    {
        instance = this;
    }
}
