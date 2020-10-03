using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(BoxCollider2D))]
public class PlayerManager : MonoBehaviour
{
    public float Speed;
    Vector2 Direction;
    Rigidbody2D rigidBody;

    public bool CanMove;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (CanMove)
        {
            Move();
        }
    }

    public void Move()
    {
        Direction.x = Input.GetAxisRaw("Horizontal");
        Direction.y = Input.GetAxisRaw("Vertical");
        Direction.Normalize();
        Direction *= Speed * Time.fixedDeltaTime;
        rigidBody.MovePosition(rigidBody.position + Direction);
    }
}
