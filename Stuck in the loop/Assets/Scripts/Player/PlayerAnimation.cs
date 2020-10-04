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

    // Start is called before the first frame update
    void Start()
    {
        playerAnimator = GetComponent<Animator>();
        direction = GetComponentInParent<PlayerMovement>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(direction.public_Direction.y > 0)
         {
             playerAnimator.SetBool("MovingDown", false);
             playerAnimator.SetBool("MovingSide", false);
             playerAnimator.SetBool("MovingUp", true);

         }

        if(direction.public_Direction.y < 0)
         {
             playerAnimator.SetBool("MovingSide", false);
             playerAnimator.SetBool("MovingUp", false);
             playerAnimator.SetBool("MovingDown", true);

         }

         if (direction.public_Direction.x > 0)
         {
             playerAnimator.SetBool("MovingUp", false);
             playerAnimator.SetBool("MovingDown", false);
             playerAnimator.SetBool("MovingSide", true);
            sprite.flipX = true;
        }

        if (direction.public_Direction.x < 0)
        {
            playerAnimator.SetBool("MovingUp", false);
            playerAnimator.SetBool("MovingDown", false);
            playerAnimator.SetBool("MovingSide", true);
            sprite.flipX = false;

        }

        if (direction.public_Direction.x==0 && direction.public_Direction.y == 0)
        {
            playerAnimator.SetBool("MovingUp", false);
            playerAnimator.SetBool("MovingDown", false);
            playerAnimator.SetBool("MovingSide", false);
        }

    }
}
