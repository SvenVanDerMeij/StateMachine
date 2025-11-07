using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Skullman : Bosses
{
    void Start()
    {
        _stateMachine = GetComponent<BossStateMachine>();
        _stateMachine.AddState(StateId.IdleID, GetComponent<Idle>());
        _stateMachine.AddState(StateId.JumpingID, GetComponent<Jumping>());
        _stateMachine.AddState(StateId.BarrierID, GetComponent<Barrier>());
        _stateMachine.AddState(StateId.ShootingID, GetComponent<Shooting>());
        _stateMachine.boss = this;

        _stateMachine.SetState(StateId.IdleID);
    }
    public override void SwapState(StateId from)
    {
        if (from == StateId.IdleID)
        {
           _stateMachine.SetState(StateId.ShootingID);
        }
        else if (from == StateId.BarrierID)
        {
            _stateMachine.SetState(StateId.IdleID);
        }
        else if (from == StateId.ShootingID)
        {
            _stateMachine.SetState(StateId.JumpingID);
        }
        else if (from == StateId.JumpingID)
            _stateMachine.SetState(StateId.BarrierID);
    }

}
