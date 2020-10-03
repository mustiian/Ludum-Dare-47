using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerManager : MonoBehaviour
{
    public float Speed;
    Vector3 Direction;
    Rigidbody rigidBody;

    public bool CanMove;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (CanMove)
        {
            Move();
        }
    }

    public void Move()
    {
        Direction.x = Input.GetAxisRaw("Horizontal");
        Direction.z = Input.GetAxisRaw("Vertical");
        Direction.Normalize();
        Direction *= Speed * Time.fixedDeltaTime;
        rigidBody.MovePosition(rigidBody.position + Direction);
    }
}
