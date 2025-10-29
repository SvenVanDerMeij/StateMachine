using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Composites;

public class Jump : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] float jumpForce;
    // Start is called before the first frame update
    public InputActionReference move;
    private bool Grounded = false;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    public void JumpUp(InputAction.CallbackContext context)
    {
        if (!context.performed)
            return;

        if (Grounded)
        {
            rb.velocity += new Vector2(0, jumpForce);
            Grounded = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Grounded = true;
        }
        
    }
}
