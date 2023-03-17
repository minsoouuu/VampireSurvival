using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
 /*
    Shovels,
    Plough,
    Hoe,
    Gun,
    Machinegun,
    Shotgun
 */

public class GetWeapon : MonoBehaviour
{
    public Image selSprite;
    [SerializeField] private List<Image> invens;
    [SerializeField] private List<InvenTory> inven;

    WeaponData weaponData;

    void Start()
    {
        selSprite = GetComponent<Image>();
    }

    public void OnClickWeapon()
    {
        /*
        for (int i = 0; i < invens.Count; i++)
        {
            if(invens[i].sprite == null)
            {
                invens[i].sprite = selSprite.sprite;

                transform.parent.GetComponent<CreateWeapon>().IsShow(false);
                GameManager.instance.isLive = true;
                return;
            }
            else if(invens[i].sprite == selSprite.sprite)
            {
                invens[i].GetComponent<InvenTory>().WeaponLV += 1;
                transform.parent.GetComponent<CreateWeapon>().IsShow(false);
                GameManager.instance.isLive = true;
                break;
            }
        }
        GameManager.instance.player.SetWeaponData(weaponData);
        */
    }

    public void OnTest()
    {
        for (int i = 0; i < inven.Count; i++)
        {
            if (inven[i].WeaponData == null)
            {
                inven[i].WeaponData = weaponData;
                inven[i].WeaponLV += 1;
                transform.parent.GetComponent<CreateWeapon>().IsShow(false);
                GameManager.instance.isLive = true;
                return;
            }
            else if (inven[i].WeaponData == weaponData)
            {
                GameManager.instance.player.curWeapons[weaponData.WeaponName].Weapon.LevelUp();
                inven[i].WeaponLV += 1;
                break;
            }
        }
        transform.parent.GetComponent<CreateWeapon>().IsShow(false);
        GameManager.instance.isLive = true;
    }
    public void SetWeaponData(WeaponData weaponData)
    {
        if (selSprite == null)
        {
            selSprite = GetComponent<Image>();
        }
        this.weaponData = weaponData;
        selSprite.sprite = this.weaponData.SelectIcon;
    }
}
