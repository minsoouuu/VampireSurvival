using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : Weapon
{
    public override void Initailize()
    {
        weapons.damage = 50f;
        weapons.shotDelay = 2f;
    }

}
