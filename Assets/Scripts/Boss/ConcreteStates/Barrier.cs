using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : BossState
{
    private float idleTimer;
    
    public override void Enter()
    {
        idleTimer = 0;
    }
    

    public override void Active()
    {
        transform.Rotate(0, 50, 0);
        idleTimer += Time.deltaTime;
        
        if (idleTimer >= 1)
        {
            GetComponent<BossStateMachine>().SwapState(StateId.BarrierID);
        }
        
    }


}