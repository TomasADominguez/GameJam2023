using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonidoControl : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip cancion1;
    public AudioClip cancion2;
    public AudioClip cancion3;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void TocarCancion(AudioClip cancion)
    {
        audioSource.clip = cancion;
        audioSource.loop = true;
        audioSource.Play();
    }

    public void TocarCancion1()
    {
        TocarCancion(cancion1);
    }

    public void TocarCancion2()
    {
        TocarCancion(cancion2);
    }

    public void TocarCancion3()
    {
        TocarCancion(cancion3);
    }

    public void PararCancion()
    {
        audioSource.Stop();
    }

    public void Volumen()
    {
        if (audioSource.mute)
        {
            audioSource.mute = false;
        }

        else
        {
            audioSource.mute = true;
        }
    }
}
