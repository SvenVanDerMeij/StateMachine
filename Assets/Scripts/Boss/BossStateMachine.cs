using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BossStateMachine : MonoBehaviour
{

    public Bosses boss;
    private Dictionary<StateId, BossState> _states = new Dictionary<StateId, BossState>();
    // kijk of ik een transtitions dictionary kan toevoegen
    private Dictionary<StateId, StateId> _transitions = new Dictionary<StateId, StateId>();
    public List<StateId> randoms;    
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
      //  _stateText.text = _currentState.GetType().Name;
    }

    public void AddState(StateId stateId, BossState bossState)
    {
        _states.Add(stateId, bossState);
    }

    public void AddTransition(StateId FromState, StateId ToState)
    {
        _transitions.Add(FromState, ToState);
    }

    public void SwapState(StateId From)
    { 
        
        if(!_transitions.ContainsKey(From))
            return;
        
        SetState(_transitions[From]);

    }

    public void Randomize()
    {
        int value = UnityEngine.Random.Range(0, randoms.Count);
        SetState(randoms[value]);
    }
}