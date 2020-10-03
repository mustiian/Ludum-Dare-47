using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxStats: MonoBehaviour
{
    [SerializeField]
    private ColorType.Color boxColor;
    [SerializeField]
    private bool _isDragable;


    private Rigidbody2D _boxRB2D;

    //Before we have spirite
    private SpriteRenderer spriteColor;

    private void Start()
    {
        _boxRB2D = GetComponent<Rigidbody2D>();
        CanBeDragged();

        //Before we have spirite
        spriteColor = GetComponentInChildren<SpriteRenderer>();
        switch (boxColor)
        {
            case ColorType.Color.red:
                spriteColor.color = Color.red;
                break;
            case ColorType.Color.blue:
                spriteColor.color = Color.blue;
                break;
            case ColorType.Color.green:
                spriteColor.color = Color.green;
                break;
        }
 
    }


    void CanBeDragged()
    {
        if (!_isDragable)
        {
            _boxRB2D.bodyType = RigidbodyType2D.Static;
        }
    }
    
}
