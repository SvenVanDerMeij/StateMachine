using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sucking : BossState
{
    private GameObject _player;
    private Rigidbody2D _playerrigidbody;
    private float SuckingTime;
    public override void Enter()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _playerrigidbody = _player.GetComponent<Rigidbody2D>();
        SuckingTime = 0;
    }
    

    public override void Active()
    {
        _player.transform.position -= new Vector3((CheckLeftRight() ? -0.1f : 0.1f), 0, 0);
        SuckingTime += Time.deltaTime;
        if (SuckingTime >= 2)
        {
            GetComponent<BossStateMachine>().SetState(StateId.IdleID);
        }
       
        
    }
    
    private bool CheckLeftRight()
    {
        return transform.position.x >= _player.transform.position.x;
    }
    
}
