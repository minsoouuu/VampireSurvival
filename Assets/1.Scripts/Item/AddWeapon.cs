using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddWeapon : MonoBehaviour
{
    [HideInInspector] public Sprite selSprite;
    [HideInInspector] public Sprite weaSprite;
    [SerializeField] private Player player;
    void Start()
    {
        selSprite = GetComponent<Image>().sprite;
    }

    void Update()
    {
        
    }

    public void OnClickWeapon()
    {
        player.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = weaSprite;
        transform.parent.gameObject.GetComponent<CreateWeapon>().weaponSprites.Remove(weaSprite);
        transform.parent.gameObject.GetComponent<CreateWeapon>().selecSprites.Remove(selSprite);
    }
}
