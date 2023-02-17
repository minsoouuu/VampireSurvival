using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct PlayerData
{
    public float speed;
    public Sprite[] standSprites;
    public Sprite[] runSprites;
    public Sprite[] deadSprites;

}

public enum State
{
    Stand,
    Run,
    Dead
}

public abstract class Player : MonoBehaviour
{
    public PlayerData playerData = new PlayerData();
    SpriteRenderer spriteRenderer;
    Animation anim;

    public abstract void Initalize();
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        Vector3 ve2 = new Vector3(x, y, 0f);
        transform.position += ve2 * Time.deltaTime * playerData.speed;
        if (transform.position.x == 0)
        {
            StartCoroutine(SetSprite(playerData.standSprites));
        }
        else
        {
            StartCoroutine(SetSprite(playerData.runSprites));
        }
    }

    IEnumerator SetSprite(Sprite[] sprites)
    {
        for (int i = 0; i < sprites.Length; i++)
        {
            spriteRenderer.sprite = sprites[i];
            yield return new WaitForSeconds(0.5f);
        }
    }
}