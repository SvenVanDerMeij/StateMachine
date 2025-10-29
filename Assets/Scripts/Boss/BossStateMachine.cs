using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStateMachine : MonoBehaviour
{
    private Dictionary<StateId, BossState> _states = new Dictionary<StateId, BossState>();
    
    private BossState _currentState;

    void Update()
    {
        if (_currentState == null)
            return;
        _currentState.Active();
    }

    public void SetState(StateId stateId)
    {
        if(!_states.ContainsKey(stateId))
            return;

        if (_currentState != null) 
            _currentState.Leave();
        
        _currentState = _states[stateId];
        
        _currentState.Enter();
    }

    public void AddState(StateId stateId, BossState bossState)
    {
        _states.Add(stateId, bossState);
    }
}