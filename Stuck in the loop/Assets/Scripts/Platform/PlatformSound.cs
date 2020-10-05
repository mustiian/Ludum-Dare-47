using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSound : MonoBehaviour
{
    private PlatformTriger platform;

    private bool playSound;

    // Start is called before the first frame update
    void Start()
    {
        platform = GetComponent<PlatformTriger>();
    }

    // Update is called once per frame
    void Update()
    {
        if (platform.activated)
        {
            if (!playSound)
            {
                playSound = true;
                PlaySound();
            }
        }
        else if (!platform.activated && playSound)
        {
            playSound = false;
        }
    }

    private void PlaySound()
    {
        SoundEffectController.instance.PlaySound(SoundEffectType.Platform);
    }
}
