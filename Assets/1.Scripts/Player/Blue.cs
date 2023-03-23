using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blue : Player
{
    private void Awake()
    {
        Initalize();
    }
    public override void Initalize()
    {
        playerData.speed = 3f;
        playerData.maxHp = 150f;
        playerData.clasicWeapon = GameManager.instance.weaponDatas[(int)ClasicWeaponType.Shovels];
        
        state = State.Stand;
        spriteRenderer = GetComponent<SpriteRenderer>();
        GetComponent<SpriteAnimation>().SetSprite(standSP, 0.1f);
    }
}
