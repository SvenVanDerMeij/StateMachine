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
        idleTimer += Time.deltaTime;
        if (idleTimer >= 1)
        {
            RandomState();
        }
        
    }

    private void RandomState()
    {
        int value = Random.Range(0, 3);
        Debug.Log(value);
        if (value == 0)
        {
            GetComponent<BossStateMachine>().SetState(StateId.SuckingID);
        } else if (value == 1)
        {
            GetComponent<BossStateMachine>().SetState(StateId.JumpingID);
        }
        else
        {
            GetComponent<BossStateMachine>().SetState(StateId.ShootingID);
        }
    }
}