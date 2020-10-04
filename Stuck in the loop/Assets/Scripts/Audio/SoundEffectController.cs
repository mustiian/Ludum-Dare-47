using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundEffectController : MonoBehaviour
{
    public static SoundEffectController instance;

    private GameObject SoundEffectParticlePrefab;

    private SoundEffectStorage soundEffectsStorage;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    private void Start()
    {
        SoundEffectParticlePrefab = Resources.Load<GameObject>("SoundEffectParticle");
        soundEffectsStorage = FindObjectOfType<SoundEffectStorage>();
    }

    public void PlaySound(SoundEffectType type)
    {
        var spawnedSound = Instantiate(SoundEffectParticlePrefab);

        if (type != SoundEffectType.None)
        {
            AudioClip soundEffect = soundEffectsStorage.GetSoundEffect(type);

            AudioSource spawnedAudioSource = spawnedSound.GetComponent<AudioSource>();
            spawnedAudioSource.clip = soundEffect;
            spawnedAudioSource.Play();
        }
    }
}
