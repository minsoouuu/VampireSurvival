using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapon" , menuName = "Scriptable Object / WeaponData")]
public class WeaponData : ScriptableObject
{
    [SerializeField] private Weapon weapon;
    public Weapon Weapon { get { return weapon; } }

    [SerializeField] private Sprite selectIcon;
    public Sprite SelectIcon { get { return selectIcon; } }

    [SerializeField] string weaponName;
    public string WeaponName { get { return weaponName; } }
}
