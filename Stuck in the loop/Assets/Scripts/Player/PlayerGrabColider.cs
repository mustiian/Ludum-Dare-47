using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGrabColider : MonoBehaviour
{

    private BoxCollider2D grabColider;


    // Start is called before the first frame update
    void Start()
    {
        grabColider = GetComponent<BoxCollider2D>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
