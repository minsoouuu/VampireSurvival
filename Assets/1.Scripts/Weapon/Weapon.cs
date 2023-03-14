using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Weapons
{
    public float damage;
    public float shotDelay;
}
public abstract class Weapon : MonoBehaviour
{
    public Weapons weapons = new Weapons();
    public abstract void Initailize();
}
