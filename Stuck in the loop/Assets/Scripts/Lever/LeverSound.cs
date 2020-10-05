using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverSound : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<LeverManager>().OnActivationLever += PlaySound;
    }

    private void PlaySound()
    {
        SoundEffectController.instance.PlaySound(SoundEffectType.Lever);
    }
}
