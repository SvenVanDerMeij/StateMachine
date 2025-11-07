using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BossStateMachine : MonoBehaviour
{
    [Serializable] public struct  state{
        public string StateId;
        public BossState bossState;
    }

    public Bosses boss;
    public state[] states;
    private Dictionary<StateId, BossState> _states = new Dictionary<StateId, BossState>();
    // kijk of ik een transtitions dictionary kan toevoegen
    private Dictionary<StateId, Bosses> _transitions = new Dictionary<StateId, Bosses>();
    [SerializeField] TextMeshProUGUI _stateText;
    private BossState _currentState;
    

    void FixedUpdate()
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

        if (_stateText != null)
            return;
        _stateText.text = _currentState.GetType().Name;
    }

    public void AddState(StateId stateId, BossState bossState)
    {
        _states.Add(stateId, bossState);
    }
}