using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class WeaponState : MonoBehaviour
{
    [SerializeField] private TMP_Text text;

    int weaponLV;
    public int WeaponLV
    {
        get { return weaponLV; }
        set 
        {
            weaponLV = value;
            text.text = weaponLV.ToString();
        }
    }
}
