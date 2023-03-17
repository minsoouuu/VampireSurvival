using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class InvenTory : MonoBehaviour
{
    [SerializeField] private TMP_Text text;
    WeaponData weaponData;
    int weaponLV;
    public int WeaponLV
    {
        get { return weaponLV; }
        set 
        {
            weaponLV = value;
            string weaponname = weaponData.WeaponName;
            if (GameManager.instance.player.curWeapons.ContainsKey(weaponname))
            {
                GameManager.instance.player.curWeapons[weaponname].Weapon.weponLv = value;
            }
            text.text = weaponLV.ToString();
        }
    }
    public WeaponData WeaponData
    {
        get { return weaponData; }
        set
        {
            weaponData = value;
            GameManager.instance.player.SetWeaponData(value);
            GetComponent<Image>().sprite = value.SelectIcon;
        }
    }
}
