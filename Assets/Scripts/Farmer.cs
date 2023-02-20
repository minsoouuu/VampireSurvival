using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Farmer : Player
{

    private void Start()
    {
        Initalize();
        state = State.Stand;
        
    }
    public override void Initalize()
    {
        playerData.speed = 3;
    }

    public override void Update()
    {
        base.Update();
    }
}
