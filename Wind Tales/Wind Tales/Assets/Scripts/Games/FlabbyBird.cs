using System.Collections;
using System.Collections.Generic;
using Games;
using Structs;
using UnityEngine;

public class FlabbyBird : MiniGames {


    public double gravity = -0.2;


    public override StatChange Play()
    {
        return new StatChange(0,0,0);
    }
    //have to make gravity work
    //have to move the chara up by a bit
    //have to make the tubes deadly
    //have to randomly make blockage appear
    //have to make that randomness appear via the diffculty stat




}
