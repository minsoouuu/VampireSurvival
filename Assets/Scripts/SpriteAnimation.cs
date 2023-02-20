using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteAnimation : MonoBehaviour
{
    List<Sprite> sprites = new List<Sprite>();
    SpriteRenderer sr;
    float spriteDelay;
    float delayTime = 0;

    int spriteIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (sprites.Count == 0)
        {
        return;
        }
        delayTime += Time.deltaTime;
        if (delayTime > spriteDelay)
        {
            delayTime = 0;
            sr.sprite = sprites[spriteIndex];
            spriteIndex++;
            if (spriteIndex > sprites.Count - 1)
            {
                spriteIndex = 0;
            }
        }
    }

    public void SetSprite(List<Sprite> sprites, float delay)
    {
        this.sprites = sprites;
        spriteDelay = delay;
        spriteIndex = 0;
    }
}

