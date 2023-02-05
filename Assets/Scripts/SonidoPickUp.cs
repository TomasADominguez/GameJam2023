using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SonidoPickUp : MonoBehaviour
{
    public AudioSource mx;
    public AudioMixerSnapshot snap;
    bool isPlaying = false;

    public PlayerTest player;
    GameObject gObject;
    Manos manos;

    void Start()
    {
        mx.volume = 0;
        mx.Play();

        gObject = GameObject.FindWithTag("Manos");
    }

    void Update()
    {
        if (isPlaying == true)
        {
            mx.volume += 0.01f;
        }

        Ruido();
    }

    void Ruido()
    {
        if (player.dropped)
        {
            snap.TransitionTo(0.01f);
            isPlaying = true;

            gameObject.GetComponent<Collider>().enabled = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<PlayerTest>(out player))
        {
            if (gObject.TryGetComponent<Manos>(out manos))
            {
                if (manos.agarrando == false)
                {
                    Debug.Log("El jugador esta escuchando...");
                }
            }
        }
    }
}
