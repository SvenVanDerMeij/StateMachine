using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomizeState : BossState
{
    public override void Active()
    {
       GetComponent<BossStateMachine>().Randomize();
    }
}