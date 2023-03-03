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
    [HideInInspector] public Sprite selSprite;
    [HideInInspector] public Sprite weaSprite;
    [SerializeField] private Player player;
    [SerializeField] private Bullet bullet;
    void Start()
    {
        selSprite = GetComponent<Image>().sprite;
    }

    void Update()
    {

    }

    public void OnClickWeapon()
    {
        if (!player.myWeapon.Contains(weaSprite))
        {
            // 무기가 없을때
            player.myWeapon.Add(weaSprite);
            player.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = weaSprite;
            Debug.Log(selSprite);
            GameManager.instance.uicont.SetMyWeaponSet(selSprite);
        }
        else
        {
            // 무기가 이미 있을때

        }
        GetComponent<Image>().color = new Color(1f, 1f, 1f,1f / 255f);
        transform.parent.gameObject.GetComponent<CreateWeapon>().weaponSprites.Remove(weaSprite);
        transform.parent.gameObject.GetComponent<CreateWeapon>().selecSprites.Remove(selSprite);

    }
}
