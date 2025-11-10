using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StateId
{
    IdleID,
    JumpingID,
    SuckingID,
    ShootingID,
    BarrierID,
    RandomID
}
public abstract class Bosses : MonoBehaviour
{
    internal BossStateMachine _stateMachine;
    
}
