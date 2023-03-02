using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] Image hpImage;
    [SerializeField] Image expImage;
    [SerializeField] GameObject deadImage;
    [SerializeField] Player player;
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
        deadImage.GetComponent<Image>().color = new Color(1f, 1f, 1f);
    }
}
