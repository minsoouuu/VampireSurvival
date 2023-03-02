using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

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
        delayTime = 0;
        this.sprites.Clear();
        this.sprites = sprites.ToList();
        spriteDelay = delay;
        spriteIndex = 0;
    }
    public void SetSprite(Sprite sprite, List<Sprite> argsprites, float delayTime)
    {
        this.delayTime = 0;
        this.sprites.Clear();
        sr.sprite = sprite;
        StartCoroutine(ReturnSprite(argsprites, delayTime));
    }

    IEnumerator ReturnSprite(List<Sprite> argsprites, float delayTime)
    {
        yield return new WaitForSeconds(0.01f);

        SetSprite(argsprites, delayTime);
    }
}

