using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
public class CreateWeapon : MonoBehaviour
{
    List<WeaponData> weaponDatas;
    [SerializeField] private List<Image> selectIcon;
    void Start()
    {
        weaponDatas = GameManager.instance.weaponDatas.ToList();
    }
    void Update()
    {
        if (GameManager.instance.isLive == false)
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.F1))
        {
            GameManager.instance.player.Exp = GameManager.instance.player.maxExp;
        }
        if (GameManager.instance.player.Exp >= GameManager.instance.player.maxExp)
        {
            GameManager.instance.isLive = false;
            GameManager.instance.player.LevelUp();
            GameObject items = GameObject.Find("ItemParent");
            int child = items.transform.childCount;
            for (int i = 0; i < child; i++)
            {
                items.transform.GetChild(i).GetComponent<Item>().StopCoroutine("ItemMove");
            }
            SetSprite();
            IsShow(true);
        }
    }
    public void SetSprite()
    {
        List<Sprite> selectedIcon = new List<Sprite>();
        
        int iconCnt = 0;
        while (iconCnt < 3)
        {
            int rand = Random.Range(0, weaponDatas.Count);
            WeaponData weaponData = weaponDatas[rand];
            if (!selectedIcon.Contains(weaponData.SelectIcon))
            {
                selectedIcon.Add(weaponData.SelectIcon);
                selectIcon[iconCnt].GetComponent<GetWeapon>().SetWeaponData(weaponData);
                iconCnt++;
            }
        }
    }
    public void IsShow(bool ison)
    {
        foreach (var item in selectIcon)
        {
            item.gameObject.SetActive(ison);
        }
    }
}
