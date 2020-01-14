using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPersistance : MonoBehaviour
{
    static bool AudioBegin = false;
    private AudioSource audioSource;
    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        if (!AudioBegin)
        {
            audioSource.Play();
            DontDestroyOnLoad(gameObject);
            AudioBegin = true;
        }
    }

    public void MusicOff()
    {
        audioSource.mute = true;
    }
    public void MusicOn()
    {
        audioSource.mute = false;
    }
}
