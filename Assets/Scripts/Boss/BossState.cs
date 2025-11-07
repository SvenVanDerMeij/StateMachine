using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BossState : MonoBehaviour
{
    public virtual void Enter() {}
    
    public virtual void Leave() {}

    public abstract void Active();
}
