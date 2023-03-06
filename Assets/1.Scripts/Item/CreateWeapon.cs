using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateWeapon : MonoBehaviour
{
    public List<Sprite> selecSprites;
    public List<Sprite> weaponSprites;
    [SerializeField] private List<Image> selectIcon;
    [SerializeField] private List<Bullet> bullets;
    void Start()
    {

    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            GameManager.instance.player.Exp += 100;
        }
        if (GameManager.instance.player.Exp >=GameManager.instance.player.maxExp)
        {
            GameManager.instance.isLive = false;
            GameManager.instance.player.LevelUp();
            SetSprite();
            IsShow(true);
        }
    }
    public void SetSprite()
    {
        List<Sprite> selectedIcon = new List<Sprite>();
        for (int i = 0; i < selectIcon.Count; i++)
        {
            int rand = Random.Range(0, selecSprites.Count);
            Sprite selSprite = selecSprites[rand];
            Sprite weaponSprite = weaponSprites[rand];
            if (!selectedIcon.Contains(selSprite) && !selectedIcon.Contains(weaponSprite))
            {
                selectedIcon.Add(selSprite);
                selectIcon[i].sprite = selSprite;
                selectIcon[i].GetComponent<AddWeapon>().SetSelSprite(selSprite);
                selectIcon[i].GetComponent<AddWeapon>().weaSprite = weaponSprite;
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
