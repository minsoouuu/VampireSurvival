using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private Image hpImage;
    [SerializeField] private Image expImage;
    [SerializeField] private GameObject deadImage;
    //[SerializeField] private List<Image> weaponImages;

    void Update()
    {
        if (GameManager.instance.isLive == false)
        {
            return;
        }
        hpImage.fillAmount = GameManager.instance.player.HP / GameManager.instance.player.MaxHp;
        expImage.fillAmount = GameManager.instance.player.Exp / GameManager.instance.player.maxExp;
    }
    public void DieImage()
    {
        deadImage.GetComponent<Image>().color = new Color(1f, 1f, 1f,1f);
    }
}
