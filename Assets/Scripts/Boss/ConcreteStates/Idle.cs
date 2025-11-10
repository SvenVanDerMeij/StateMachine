using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idle : BossState
{
    private float idleTimer;
    public override void Enter()
    {
        idleTimer = 0;
    }
    
    public override void Active()
    {
        idleTimer += Time.deltaTime;
        if (idleTimer >= 1)
        {
            GetComponent<BossStateMachine>().SwapState(StateId.IdleID);
        }
    }
}
