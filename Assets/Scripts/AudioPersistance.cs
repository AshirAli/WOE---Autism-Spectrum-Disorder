using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPersistance : MonoBehaviour
{
    static bool AudioBegin = false;
    private AudioSource audio;
    void Awake()
    {
        audio = GetComponent<AudioSource>();
        if (!AudioBegin)
        {
            audio.Play();
            DontDestroyOnLoad(gameObject);
            AudioBegin = true;
        }
    }
}
