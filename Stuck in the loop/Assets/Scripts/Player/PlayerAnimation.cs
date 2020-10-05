using Game;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(Animator))]
//[RequireComponent(typeof(PlayerMovement))]

public class PlayerAnimation : MonoBehaviour
{
    private Animator playerAnimator;
    private PlayerMovement direction;
    private SpriteRenderer sprite;

    [SerializeField] private Trigger2D triggerUp;
    [SerializeField] private Trigger2D triggerDown;
    [SerializeField] private Trigger2D triggerRight;
    [SerializeField] private Trigger2D triggerLeft;

    private Rigidbody2D rigidBody;

    void Start()
    {
        playerAnimator = GetComponent<Animator>();
        direction = GetComponentInParent<PlayerMovement>();
        sprite = GetComponent<SpriteRenderer>();

        triggerDown.OnEnter += BoxMoveDown;
        triggerUp.OnEnter += BoxMoveUp;
        triggerRight.OnEnter += BoxMoveRight;
        triggerLeft.OnEnter += BoxMoveLeft;

        triggerDown.OnExit += StopBoxMoveDown;
        triggerUp.OnExit += StopBoxMoveUp;
        triggerRight.OnExit += StopBoxMoveRight;
        triggerLeft.OnExit += StopBoxMoveLeft;


        rigidBody = GetComponentInParent<Rigidbody2D>();

    }

    private void BoxMoveDown(Collider2D other)
    {
        //playerAnimator.SetBool("MovingDown", false);
        playerAnimator.SetBool("DragDown", true);
    }

    private void BoxMoveUp(Collider2D other)
    {
        //playerAnimator.SetBool("MovingUp", false);
        playerAnimator.SetBool("DragUp", true);
    }

    private void BoxMoveRight(Collider2D other)
    {
        //playerAnimator.SetBool("MovingRight", false);
        playerAnimator.SetBool("DragRight", true);
    }

    private void BoxMoveLeft(Collider2D other)
    {
        //playerAnimator.SetBool("MovingLeft", false);
        playerAnimator.SetBool("DragLeft", true);
    }

    private void StopBoxMoveDown(Collider2D other)
    {
        //playerAnimator.SetBool("MovingDown", true);
        playerAnimator.SetBool("DragDown", false);
    }

    private void StopBoxMoveUp(Collider2D other)
    {
        //playerAnimator.SetBool("MovingUp", true);
        playerAnimator.SetBool("DragUp", false);
    }

    private void StopBoxMoveRight(Collider2D other)
    {
        //playerAnimator.SetBool("MovingSide", true);
        playerAnimator.SetBool("DragRight", false);
    }

    private void StopBoxMoveLeft(Collider2D other)
    {
        //playerAnimator.SetBool("MovingSide", true);
        playerAnimator.SetBool("DragLeft", false);
    }


    void LateUpdate()
    {
        MoveAnimation();
    }

    void MoveAnimation()
    {
        if (direction.public_Direction.y > 0)
        {
            playerAnimator.SetBool("MovingDown", false);
            playerAnimator.SetBool("MovingRight", false);
            playerAnimator.SetBool("MovingLeft", false);
            playerAnimator.SetBool("MovingUp", true);
        }

        if (direction.public_Direction.y < 0)
        {
            playerAnimator.SetBool("MovingLeft", false);
            playerAnimator.SetBool("MovingRight", false);
            playerAnimator.SetBool("MovingUp", false);
            playerAnimator.SetBool("MovingDown", true);
        }

        if (direction.public_Direction.x > 0)
        {
            playerAnimator.SetBool("MovingUp", false);
            playerAnimator.SetBool("MovingDown", false);
            playerAnimator.SetBool("MovingLeft", false);
            playerAnimator.SetBool("MovingRight", true);
        }

        if (direction.public_Direction.x < 0)
        {
            playerAnimator.SetBool("MovingUp", false);
            playerAnimator.SetBool("MovingDown", false);
            playerAnimator.SetBool("MovingRight", false);
            playerAnimator.SetBool("MovingLeft", true);      
        }

        if (direction.public_Direction.x == 0 && direction.public_Direction.y == 0)
        {
            playerAnimator.SetBool("MovingUp", false);
            playerAnimator.SetBool("MovingDown", false);
            playerAnimator.SetBool("MovingRight", false);
            playerAnimator.SetBool("MovingLeft", false);
        }
    }
}
