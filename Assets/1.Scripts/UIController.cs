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
        int childs = transform.GetChild(0).GetChild(3).childCount;
        for (int i = 0; i < childs; i++)
        {
            Debug.Log(transform.GetChild(0).GetChild(3).GetChild(i));
        }
    }

    void Update()
    {
        hpImage.fillAmount = player.HP / player.playerData.maxHp;
        expImage.fillAmount = player.Exp / player.maxExp;

       
    }
    public void DieImage()
    {
        deadImage.GetComponent<Image>().color = new Color(1f, 1f, 1f,1f);
    }
}
