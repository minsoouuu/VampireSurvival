using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateWeapon : MonoBehaviour
{
    public List<Sprite> selecSprites;
    public List<Sprite> weaponSprites;
    [SerializeField] private List<Image> images;
    [SerializeField] private List<Bullet> bullets;
    void Start()
    {
        SetSprite();
    }
    void Update()
    {
        
    }
    public void SetSprite()
    {
        for (int i = 0; i < images.Count; i++)
        {
            if (images[i].sprite == null)
            {
                int rand = Random.Range(0, selecSprites.Count);

                Sprite selSprite = selecSprites[rand];
                Sprite weaponSprite = weaponSprites[rand];

                images[i].sprite = selSprite;
                images[i].GetComponent<AddWeapon>().weaSprite = weaponSprite;
                images[i].GetComponent<AddWeapon>().selSprite = selSprite;
            }
            
        }
    }
}
