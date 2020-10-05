using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSound : MonoBehaviour
{
    public float Delay;

    private PlayerMovement playerMovement;

    private bool playSound;

    // Start is called before the first frame update
    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerMovement.public_Direction != Vector2.zero)
        {
            if (!playSound)
            {
                playSound = true;
                PlaySound();
            }
        }
    }

    public IEnumerator DelayStepSound(float delay)
    {
        yield return new WaitForSeconds(delay);

        playSound = false;
    }

    private void PlaySound()
    {
        int soundEffect = Random.Range(1, 4);

        switch (soundEffect)
        {
            case 1:
                SoundEffectController.instance.PlaySound(SoundEffectType.Step1);
                break;
            case 2:
                SoundEffectController.instance.PlaySound(SoundEffectType.Step2);
                break;
            case 3:
                SoundEffectController.instance.PlaySound(SoundEffectType.Step3);
                break;
            default:
                break;
        }

        StartCoroutine(DelayStepSound(Delay));
    }
}
