using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SonidoPickUp : MonoBehaviour
{
    public AudioSource aSource;
    public AudioMixer mx;
    public AudioMixerSnapshot snap;
    bool isPlaying = false;
    public string volume;
    public float mxVolume;

    public PlayerTest player;
    GameObject gObject;
    Manos manos;

    void Start()
    {
        mx.SetFloat(volume, -80);
        gObject = GameObject.FindWithTag("Manos");
    }

    void Update()
    {
        if (isPlaying == true)
        {
            mxVolume += 0.8f * Time.deltaTime;
            mx.SetFloat(volume, mxVolume);
        }

        //Ruido();
    }

    void Ruido()
    {
        if (player.dropped == true)
        {
            snap.TransitionTo(0.01f);
            isPlaying = true;

            gameObject.GetComponent<Collider>().enabled = false;
        }

        else
        {
            gameObject.GetComponent<Collider>().enabled = true;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("1");
        if (other.gameObject.TryGetComponent<PlayerTest>(out player))
        {
            Debug.Log("2");

            if(gObject.TryGetComponent<Manos>(out manos))
            {
                if (manos.agarrando)
                {
                    aSource.Play();
                    snap.TransitionTo(0.01f);
                    isPlaying = true;

                    gameObject.GetComponent<Collider>().enabled = false;
                }
            }

            

            /*if (gObject.TryGetComponent<Manos>(out manos))
            {
                Debug.Log("3");
                if (manos.agarrando == false)
                {
                    Debug.Log("El jugador esta escuchando...");
                }
            }*/
        }
    }
}
