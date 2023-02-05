using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonidoControl : MonoBehaviour
{
    public AudioSource audioSource;

    public AudioClip backgroundMusic1;
    public AudioClip backgroundMusic2;
    public AudioClip backgroundMusic3;

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
        TocarCancion(backgroundMusic1);
    }

    public void TocarCancion2()
    {
        TocarCancion(backgroundMusic2);
    }

    public void TocarCancion3()
    {
        TocarCancion(backgroundMusic3);
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
