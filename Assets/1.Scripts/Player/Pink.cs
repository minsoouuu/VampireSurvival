using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pink : Player
{
    private void Awake()
    {
        Initalize();
    }
    public override void Initalize()
    {
        playerData.speed = 5f;
        playerData.maxHp = 100f;
        state = State.Stand;
        spriteRenderer = GetComponent<SpriteRenderer>();
        GetComponent<SpriteAnimation>().SetSprite(standSP,0.1f);
    }
}
