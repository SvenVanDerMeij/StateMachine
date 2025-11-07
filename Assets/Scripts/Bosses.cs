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
    BarrierID
}
public abstract class Bosses : MonoBehaviour
{
    public virtual void SwapState(StateId from)
    {
        Debug.Log(from.ToString());
    }
}
