using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

enum WeaponData
{
    None,
    Shovels,
    Plough,
    Hoe,
    Gun,
    Machinegun,
    Shotgun
}

enum BulletDatas
{
    None,
    ShovelsBullet,
    PloughBullet,
    HoeBullet,
    GunBullet,
    MachinegunBullet,
    ShotgunBullet
}

public class AddWeapon : MonoBehaviour
{
    public Image selSprite;
    [HideInInspector] public Sprite weaSprite;
    [SerializeField] private Bullet bullet;

    [SerializeField] private List<Image> invens;

    void Start()
    {
        selSprite = GetComponent<Image>();
    }

    void Update()
    {

    }

    /*
     if (!invens.Contains(selSprite))
            {
                invens[i].sprite = selSprite.sprite;

                GameManager.instance.player.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = weaSprite;
                transform.parent.GetComponent<CreateWeapon>().IsShow(false);
                GameManager.instance.isLive = true;
                break;
            }
            else
            {
                invens[i].transform.GetChild(0).GetComponent<TextMeshPro>().text += 1;
                transform.parent.GetComponent<CreateWeapon>().IsShow(false);
                GameManager.instance.isLive = true;
                break;
            } 
     */

    public void OnClickWeapon()
    {
        for (int i = 0; i < invens.Count; i++)
        {
            if(invens[i].sprite == null)
            {
                invens[i].sprite = selSprite.sprite;

                GameManager.instance.player.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = weaSprite;
                transform.parent.GetComponent<CreateWeapon>().IsShow(false);
                GameManager.instance.isLive = true;
                return;
            }
            else if(invens[i].sprite == selSprite.sprite)
            {
                //invens[i].transform.GetChild(0).GetComponent<TMP_Text>().text += 1;
                invens[i].GetComponent<WeaponState>().WeaponLV += 1;
                transform.parent.GetComponent<CreateWeapon>().IsShow(false);
                GameManager.instance.isLive = true;
                break;
            }
        }
    }
}
