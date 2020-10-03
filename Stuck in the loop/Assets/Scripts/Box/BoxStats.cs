using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxStats: MonoBehaviour
{
    public enum BoxColors { red, green, blue };

    [SerializeField]
    private BoxColors boxColor;
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
            case BoxColors.red:
                spriteColor.color = Color.red;
                break;
            case BoxColors.blue:
                spriteColor.color = Color.blue;
                break;
            case BoxColors.green:
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
