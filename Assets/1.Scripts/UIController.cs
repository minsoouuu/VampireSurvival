using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class UIController : MonoBehaviour
{
    [SerializeField] private Image hpImage;
    [SerializeField] private Image expImage;
    [SerializeField] private GameObject deadImage;
    [SerializeField] private TMP_Text timeText;
    float time = 0;
    //[SerializeField] private List<Image> weaponImages;
   
    void Start()
    {
        GameManager.instance.uicont = this;

    }
    void Update()
    {
        if (GameManager.instance.isLive == false)
        {
            return;
        }
        time += Time.deltaTime;
        double num = Math.Truncate(time * 100) / 100;
        timeText.text = num.ToString();
        hpImage.fillAmount = GameManager.instance.player.HP / GameManager.instance.player.MaxHp;
        expImage.fillAmount = GameManager.instance.player.Exp / GameManager.instance.player.maxExp;
    }
    public void DieImage()
    {
        deadImage.GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);
        //StartCoroutine(DieImageColor());
    }

    IEnumerator DieImageColor()
    {
        for (int i = 0; i < 255; i++)
        {
            deadImage.GetComponent<Image>().color = new Color(1f, 1f, 1f, i / 255);
            yield return new WaitForSeconds(0.01f);
        }
    }
}
