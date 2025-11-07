using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BossStateMachine : MonoBehaviour
{
    private Dictionary<StateId, BossState> _states = new Dictionary<StateId, BossState>();
    // kijk of ik een transtitions dictionary kan toevoegen
    
    [SerializeField] TextMeshProUGUI _stateText;
    private BossState _currentState;

    void FixedUpdate()
    {
        if (_currentState == null)
            return;
        _currentState.Active();
        
        Debug.Log(_currentState.GetType().Name);    
    }

    public void SetState(StateId stateId)
    {
        if(!_states.ContainsKey(stateId))
            return;

        if (_currentState != null) 
            _currentState.Leave();
        
        _currentState = _states[stateId];
        
        _currentState.Enter();
        
        _stateText.text = _currentState.GetType().Name;
    }

    public void AddState(StateId stateId, BossState bossState)
    {
        _states.Add(stateId, bossState);
    }

    public void SetIdle()
    {
        SetState(StateId.IdleID);
    }
    public void SetShoot()
    {
        SetState(StateId.ShootingID);
    }
    public void SetSuck()
    {
        SetState(StateId.SuckingID);
    }
    public void SetJump()
    {
        SetState(StateId.JumpingID);
    }
}