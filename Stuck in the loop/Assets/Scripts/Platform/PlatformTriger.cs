using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformTriger : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Game.BoxTrigger2D trigger;

    public bool activated = false;
    public int platformColor; // 1 red, 2 green

    private void Awake()
    {
        trigger.OnEnter += OnMyTriggerEnter;
        trigger.OnExit += OnMyTriggerExit;
    }

    private void OnMyTriggerEnter(Collider2D other)
    {
        Debug.Log($"Box is on platform: {name}");
        activated = true;

        if (other.gameObject.tag == "Box" && platformColor == other.gameObject.GetComponent<BoxStats>().boxColor)
        {
            other.transform.position = this.transform.position;
            other.gameObject.GetComponent<BoxStats>().isOnPlatform = true;
            other.gameObject.GetComponent<BoxStats>().boxColor = platformColor;
            other.gameObject.GetComponent<BoxStats>()._isDragable = false;
        }
        

    }

    private void OnMyTriggerExit(Collider2D triggered)
    {
        Debug.Log($"Box is out platform: {name}");
    }
}

