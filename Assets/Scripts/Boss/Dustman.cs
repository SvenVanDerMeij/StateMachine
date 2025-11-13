using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = System.Random;


public class Dustman : Bosses
{
    void Start()
    {
     _stateMachine = GetComponent<BossStateMachine>();
     _stateMachine.AddState(StateId.IdleID, 
         GetComponent<Idle>());
     _stateMachine.AddState(StateId.JumpingID, 
         GetComponent<Jumping>());
     _stateMachine.AddState(StateId.SuckingID, 
         GetComponent<Sucking>());
     _stateMachine.AddState(StateId.ShootingID, 
         GetComponent<Shooting>());
     _stateMachine.AddState(StateId.RandomID, 
         GetComponent<RandomizeState>());
     
     _stateMachine.boss = this;
     
     _stateMachine.AddTransition(StateId.IdleID, 
         StateId.RandomID);
     _stateMachine.AddTransition(StateId.JumpingID, 
         StateId.SuckingID);
     _stateMachine.AddTransition(StateId.SuckingID, 
         StateId.IdleID);
     _stateMachine.AddTransition(StateId.ShootingID, 
         StateId.IdleID);
     
     _stateMachine.randoms.Add(StateId.ShootingID);
     _stateMachine.randoms.Add(StateId.SuckingID);
     _stateMachine.randoms.Add(StateId.JumpingID);
     
     _stateMachine.SetState(StateId.IdleID);
    }
}