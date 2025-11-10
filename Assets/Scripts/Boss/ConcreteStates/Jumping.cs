using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Jumping : BossState
{
    private GameObject _player;
    private Rigidbody2D rb;
    private bool airborne;
    private float Jumpforce;
    private float distance;
    
    
    public override void Enter()
    {
        airborne = false;
        _player = GameObject.FindGameObjectWithTag("Player");
        
        rb = GetComponent<Rigidbody2D>();
        
        distance = Vector3.Distance(transform.position, _player.transform.position);
        rb.AddForce(new Vector2(CheckLeftRight() ? -70*distance : 70*distance, 1000f));
        airborne = true;
    }

    public override void Leave()
    {
      
    }

    public override void Active()
    {
        
    }
    private bool CheckLeftRight()
    {
        //Vector2Distance.
        return transform.position.x >= _player.transform.position.x;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Ground")) return;
        if (!airborne) return;
        GetComponent<BossStateMachine>().SwapState(StateId.JumpingID);
    }
}
