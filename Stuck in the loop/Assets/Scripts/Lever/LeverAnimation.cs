using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverAnimation : MonoBehaviour
{
    public Sprite LeftLever;
    public Sprite RightLever;

    private SpriteRenderer sprite;
    
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<LeverManager>().OnActivationLever += ChangeAnimation;
        sprite = GetComponentInChildren<SpriteRenderer>();
        sprite.sprite = LeftLever;
    }

    public void ChangeAnimation()
    {
        if (sprite.sprite.name == LeftLever.name)
            sprite.sprite = RightLever;
        else
            sprite.sprite = LeftLever;
    }
}
