using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Game.Trigger2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class RoomSectionFade : MonoBehaviour
{

    [SerializeField] private Game.Trigger2D trigger;
    [SerializeField] private AnimationCurve curve;

    private SpriteRenderer sprite;

    public float duration = 2f;

    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        trigger.OnEnter += OnMyTriggerEnter;

    }

    IEnumerator Fade()
    {
        Color color = sprite.color;

        for (float t = 0f; t < 1f; t = Mathf.Min(1f, t + (Time.deltaTime / duration))) 
        {
            color.a = curve.Evaluate(1 - t);
            sprite.color = color;
            yield return null;
        }

        Destroy(this.gameObject);
    }


    private void OnMyTriggerEnter(Collider2D triggered)
    {
        StartCoroutine(Fade());
    }

}




