using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public enum StateId
{
    NullStateId,
    IdleID,
    JumpingID,
    SuckingID,
    ShootingID
}
public class Dustman : MonoBehaviour
{
    private BossStateMachine _stateMachine;
    void Start()
    {
        
     _stateMachine = GetComponent<BossStateMachine>();

     _stateMachine.AddState(StateId.IdleID, GetComponent<Idle>());
     _stateMachine.AddState(StateId.JumpingID, GetComponent<Jumping>());
     _stateMachine.AddState(StateId.SuckingID, GetComponent<Sucking>());
     _stateMachine.AddState(StateId.ShootingID, GetComponent<Shooting>());
     
     _stateMachine.SetState(StateId.IdleID);
    }

    
}
