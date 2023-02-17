using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Farmer : Player
{
    [SerializeField] private Sprite[] standSprites;
    [SerializeField] private Sprite[] runSprites;
    [SerializeField] private Sprite[] deadSprites;
    public override void Initalize()
    {
        playerData.speed = 3;
    }
}
