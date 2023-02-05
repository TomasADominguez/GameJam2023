using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTest : MonoBehaviour
{
    Rigidbody rb;
    public float speed;

    RamaTrigger ramaTrigger;
    Pickable objetoTrigger;

    public Transform objetoEnManos;
    public Manos manos;

    SonidoControl sonidoControl;
    SonidoPickUp sonidoPickUp;
    public bool dropped = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        sonidoControl = FindObjectOfType<SonidoControl>();
    }

    // Update is called once per frame
    void Update()
    {
        float movHorizontal = Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime;
        float movVertical = Input.GetAxisRaw("Vertical") * speed * Time.deltaTime;

        transform.Translate(movHorizontal, movVertical, 0);
    }

    void PickUp(GameObject objeto)
    {
        objeto.transform.position = objetoEnManos.position;
        objeto.transform.rotation = objetoEnManos.rotation;

        objeto.transform.SetParent(objetoEnManos);
    }

    void Drop(GameObject objeto, Transform newParent)
    {
        objeto.transform.position = newParent.transform.position;
        objeto.transform.rotation = newParent.transform.rotation;

        objeto.transform.SetParent(newParent);
    }

    void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.TryGetComponent<RamaTrigger>(out ramaTrigger))
        {
            if (ramaTrigger.ramaA)
            {
                Debug.Log("Escuchando musica ramaA...");

                if (sonidoControl.audioSource.clip != sonidoControl.backgroundMusic1)
                {
                    sonidoControl.TocarCancion1();
                }
                sonidoControl.Volumen();

                /*if (ramaTrigger.tengoHijo == false && manos.agarrando)
                {
                    Drop(manos.hijo, collider.transform);
                }*/
            }

            if (ramaTrigger.ramaB)
            {
                Debug.Log("Escuchando musica ramaB...");

                if (sonidoControl.audioSource.clip != sonidoControl.backgroundMusic2)
                {
                    sonidoControl.TocarCancion2();
                }
                sonidoControl.Volumen();

                /*if (ramaTrigger.tengoHijo == false && manos.agarrando)
                {
                    Drop(manos.hijo, collider.transform);
                }*/
            }

            if (ramaTrigger.ramaC)
            {
                Debug.Log("Escuchando musica ramaC...");

                if (sonidoControl.audioSource.clip != sonidoControl.backgroundMusic3)
                {
                    sonidoControl.TocarCancion3();
                }
                sonidoControl.Volumen();

                /*if (ramaTrigger.tengoHijo == false && manos.agarrando)
                {
                    Drop(manos.hijo, collider.transform);
                }*/
            }
        }

        if (collider.gameObject.TryGetComponent<Pickable>(out objetoTrigger))
        {
            if (objetoEnManos.TryGetComponent<Manos>(out manos))
            {
                if (manos.agarrando == false)
                {
                    PickUp(collider.gameObject);
                    dropped = false;
                }
            }
        }

        if (collider.gameObject.TryGetComponent<SonidoPickUp>(out sonidoPickUp))
        {
            if (manos.agarrando)
            {
                Drop(manos.hijo, collider.transform);
                dropped = true;
            }
            
        }
    }

    void OnTriggerExit(Collider collider)
    {
        if(collider.gameObject.TryGetComponent<RamaTrigger>(out ramaTrigger))
        {
            if (ramaTrigger.ramaA)
            {
                Debug.Log("Ya no se escucha...");
                sonidoControl.Volumen();
            }

            if (ramaTrigger.ramaB)
            {
                Debug.Log("Ya no se escucha...");
                sonidoControl.Volumen();
            }

            if (ramaTrigger.ramaC)
            {
                Debug.Log("Ya no se escucha...");
                sonidoControl.Volumen();
            }
        }
    }
}
