using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxStats: MonoBehaviour
{
    public int boxColor;

    public bool _isDragable;


    private Rigidbody2D _boxRB2D;

    //Before we have spirite
    private SpriteRenderer spriteColor;

    public bool isOnPlatform;

    private void Start()
    {
        _boxRB2D = GetComponent<Rigidbody2D>();
    }


    private void Update()
    {
        if (isOnPlatform)
        {
            CanBeDragged();

            //Before we have spirite
            spriteColor = GetComponentInChildren<SpriteRenderer>();
            switch (boxColor)
            {
                case 1:
                    spriteColor.color = Color.red;
                    break;
                case 2:
                    spriteColor.color = Color.green;
                    break;
                case 3:
                    spriteColor.color = Color.blue;
                    break;
            }
        }
    }


    public bool IsDragable()
    {
        return _isDragable;
    }

    void CanBeDragged()
    {
        if (!_isDragable)
        {
            _boxRB2D.bodyType = RigidbodyType2D.Static;
        }
    }



}
