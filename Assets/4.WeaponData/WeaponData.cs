using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapon" , menuName = "Scriptable Object / WeaponData")]
public class WeaponData : ScriptableObject
{
    [SerializeField] private Weapon weapon;
    public Weapon Weapon { get { return weapon; } }

    [SerializeField] private Bullet bullet;
    public Bullet Bullet { get { return bullet; } }

    [SerializeField] private Sprite selectIcon;
    public Sprite SelectIcon { get { return selectIcon; } }
    
    [SerializeField] private float damage;
    public float Damage { get { return damage; } }

    [SerializeField] private float shotDelay;
    public float ShotDelay { get { return shotDelay; } }
}
