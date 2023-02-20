using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Farmer : Player
{

    private void Start()
    {
        Initalize();
    }
    public override void Initalize()
    {
        playerData.speed = 3;
        state = State.Stand;
        spriteRenderer = GetComponent<SpriteRenderer>();
        GetComponent<SpriteAnimation>().SetSprite(standSP,0.1f);
    }
}
