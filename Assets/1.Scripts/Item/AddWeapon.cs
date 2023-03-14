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

public class AddWeapon : MonoBehaviour
{
    public Image selSprite;
    [HideInInspector] public Sprite weaSprite;
    [SerializeField] private Bullet bullet;
    [SerializeField] private List<Image> invens;

    WeaponData weaponData;

    void Start()
    {
        selSprite = GetComponent<Image>();
    }

    public void OnClickWeapon()
    {
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
                invens[i].GetComponent<WeaponState>().WeaponLV += 1;
                transform.parent.GetComponent<CreateWeapon>().IsShow(false);
                GameManager.instance.isLive = true;
                break;
            }
        }
        GameManager.instance.player.SetWeaponData(weaponData);
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
