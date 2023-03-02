using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] Image hpImage;
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
    }
    public void DieImage()
    {
        transform.GetChild(0).gameObject.SetActive(true);
    }
}
