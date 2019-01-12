using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    [HideInInspector] private bool jump = false;
    public float forceMagnitude = 3;
    private Rigidbody2D body;
    public float jumpSpeed = 10;
    public LayerMask groundLayer;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            Jump();
        }
    }

    private void FixedUpdate()
    {
        float xMovement = Input.GetAxis("Horizontal");
        Vector2 vel = body.velocity;
        vel.x = xMovement * 10;
        body.velocity = vel;
    }

    void Jump()
    {
        if (!IsGrounded())
        {
            return;
        }
        else
        {
            body.velocity = Vector2.up * jumpSpeed;
        }
    }

    bool IsGrounded()
    {
        Vector2 position = transform.position;
        Vector2 direction = Vector2.down;
        float distance = 2.0f;
        Debug.DrawRay(position, direction, Color.green);
        RaycastHit2D hit = Physics2D.Raycast(position, direction, distance, groundLayer);

        if (hit.collider != null)
        {
            return true;
        }

        return false;
    }
}
