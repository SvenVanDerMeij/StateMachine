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
        _stateMachine.AddState(StateId.IdleID, 
            GetComponent<Idle>());
        _stateMachine.AddState(StateId.JumpingID, 
            GetComponent<Jumping>());
        _stateMachine.AddState(StateId.BarrierID, 
            GetComponent<Barrier>());
        _stateMachine.AddState(StateId.ShootingID, 
            GetComponent<Shooting>());
        
        _stateMachine.boss = this;
        
        _stateMachine.AddTransition(StateId.IdleID, 
            StateId.ShootingID);
        _stateMachine.AddTransition(StateId.BarrierID,
            StateId.IdleID);
        _stateMachine.AddTransition(StateId.ShootingID, 
            StateId.JumpingID);
        _stateMachine.AddTransition(StateId.JumpingID,
            StateId.BarrierID);

        _stateMachine.SetState(StateId.IdleID);
    }
    
}
