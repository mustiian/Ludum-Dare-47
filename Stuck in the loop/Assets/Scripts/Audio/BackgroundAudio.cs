using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundAudio : MonoBehaviour
{
    public AudioClip music;

    private AudioSource audioSource;

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);

        audioSource = GetComponent<AudioSource>();
        audioSource.clip = music;
        audioSource.loop = true;
    }

    private void Start()
    {
        audioSource.Play();
    }
}
