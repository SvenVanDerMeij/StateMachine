using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Composites;

public class Move : MonoBehaviour
{
    [SerializeField] float speed;
    // Start is called before the first frame update
    public InputActionReference move;
    private bool Grounded = false;
    private void FixedUpdate()
    {
        transform.Translate(move.action.ReadValue<float>() * speed * Time.deltaTime ,0,0);
    }
}
