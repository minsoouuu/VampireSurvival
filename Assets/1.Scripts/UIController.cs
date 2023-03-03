using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private Image hpImage;
    [SerializeField] private Image expImage;
    [SerializeField] private GameObject deadImage;
    [SerializeField] private Player player;
    [SerializeField] private List<Image> weaponImages;
    void Start()
    {
        player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        hpImage.fillAmount = player.HP / player.playerData.maxHp;
        expImage.fillAmount = player.Exp / player.maxExp;
    }
    public void DieImage()
    {
        deadImage.GetComponent<Image>().color = new Color(1f, 1f, 1f,1f);
    }

    public void SetMyWeaponSet(Sprite sprite)
    {
        for (int i = 0; i < weaponImages.Count; i++)
        {
            if (weaponImages[i].GetComponent<Image>().sprite == null)
            {
                weaponImages[i].GetComponent<Image>().sprite = sprite;
                break;
            }
        }
    }
}
