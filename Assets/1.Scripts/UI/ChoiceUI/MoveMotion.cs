using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMotion : MonoBehaviour
{
    [SerializeField] private List<Sprite> sprites;

    private void Start()
    {
        GetComponent<SpriteAnimation>().SetSprite(sprites, 0.1f);
    }
}
