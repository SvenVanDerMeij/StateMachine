using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;


public class Dustman : Bosses
{
    


    void Start()
    {
     _stateMachine = GetComponent<BossStateMachine>();
     _stateMachine.AddState(StateId.IdleID, GetComponent<Idle>());
     _stateMachine.AddState(StateId.JumpingID, GetComponent<Jumping>());
     _stateMachine.AddState(StateId.SuckingID, GetComponent<Sucking>());
     _stateMachine.AddState(StateId.ShootingID, GetComponent<Shooting>());
     _stateMachine.boss = this;

     _stateMachine.SetState(StateId.IdleID);
    }
    public override void SwapState(StateId from)
    {
        if (from == StateId.IdleID)
        {
            RandomState();
        }
        else if (from == StateId.SuckingID)
        {
            _stateMachine.SetState(StateId.IdleID);
        }
        else if (from == StateId.ShootingID)
        {
            _stateMachine.SetState(StateId.IdleID);
        }
        else if (from == StateId.JumpingID)
        _stateMachine.SetState(StateId.SuckingID);
    }
    
    private void RandomState()
    {
        int value = UnityEngine.Random.Range(0, 3);
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
