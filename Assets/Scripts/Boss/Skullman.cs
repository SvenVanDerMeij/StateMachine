using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Skullman : Bosses
{
    private BossStateMachine _stateMachine;


    void Start()
    {
        _stateMachine = GetComponent<BossStateMachine>();
        _stateMachine.AddState(StateId.IdleID, GetComponent<Idle>());
        _stateMachine.AddState(StateId.JumpingID, GetComponent<Jumping>());
        _stateMachine.AddState(StateId.ShootingID, GetComponent<Shooting>());
        _stateMachine.AddState(StateId.BarrierID, GetComponent<Barrier>());
        
        
        _stateMachine.SetState(StateId.IdleID);
    }


}
