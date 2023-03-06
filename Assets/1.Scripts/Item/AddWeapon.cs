using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    void Start()
    {
        selSprite = GetComponent<Image>();
    }

    void Update()
    {

    }

    public void SetSelSprite(Sprite sprite)
    {
        selSprite.sprite = sprite;
    }

    public void OnClickWeapon()
    {
        if (!GameManager.instance.player.myWeaponIvens.Contains(selSprite))
        {
            // 무기가 없을때
            GameManager.instance.isLive = true;
            transform.parent.GetComponent<CreateWeapon>().IsShow(false);
            GameManager.instance.player.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = weaSprite;
            GameManager.instance.player.SetInven(selSprite.sprite);
        }
        else
        {
            //무기가 있을때
        }
    }
}
