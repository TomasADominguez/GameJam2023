using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTest : MonoBehaviour
{
    //Rigidbody rb;
    //public float speed;

    //RamaTrigger ramaTrigger;

    //public Transform objetoEnManos;
    //Manos manos;

    //void Start()
    //{
    //    rb = GetComponent<Rigidbody>();
    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    float movHorizontal = Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime;
    //    float movVertical = Input.GetAxisRaw("Vertical") * speed * Time.deltaTime;

    //    transform.Translate(movHorizontal, movVertical, 0);
    //}

    //void PickUp(GameObject objeto)
    //{
    //    objeto.transform.position = objetoEnManos.position;
    //    objeto.transform.rotation = objetoEnManos.rotation;

    //    objeto.transform.SetParent(objetoEnManos);
    //}

    //void Drop(GameObject objeto, Transform newParent)
    //{
    //    objeto.transform.position = newParent.transform.position;
    //    objeto.transform.rotation = newParent.transform.rotation;

    //    objeto.transform.SetParent(newParent);
    //}

    //void OnTriggerEnter(Collider collider)
    //{
    //    if(collider.gameObject.TryGetComponent<RamaTrigger>(out ramaTrigger))
    //    {
    //        if (ramaTrigger.ramaA)
    //        {
    //            Debug.Log("Escuchando musica ramaA...");

    //            if (ramaTrigger.tengoHijo == false)
    //            {
    //                Drop(manos.hijo, collider.transform);
    //            }
    //        }

    //        if (ramaTrigger.ramaB)
    //        {
    //            Debug.Log("Escuchando musica ramaB...");

    //            if (ramaTrigger.tengoHijo == false)
    //            {
    //                Drop(manos.hijo, collider.transform);
    //            }
    //        }

    //        if (ramaTrigger.ramaC)
    //        {
    //            Debug.Log("Escuchando musica ramaC...");
                
    //            if (ramaTrigger.tengoHijo == false)
    //            {
    //                Drop(manos.hijo, collider.transform);
    //            }
    //        }
    //    }

    //    if (collider.gameObject.tag == "Objeto")
    //    {
    //        if (objetoEnManos.TryGetComponent<Manos>(out manos))
    //        {
    //            if (manos.agarrando == false)
    //            {
    //                PickUp(collider.gameObject);
    //            }
    //        }
    //    }
    //}

    //void OnTriggerExit(Collider collider)
    //{
    //    if(collider.gameObject.TryGetComponent<RamaTrigger>(out ramaTrigger))
    //    {
    //        if (ramaTrigger.ramaA)
    //        {
    //            Debug.Log("Ya no se escucha...");
    //        }

    //        if (ramaTrigger.ramaB)
    //        {
    //            Debug.Log("Ya no se escucha...");
    //        }

    //        if (ramaTrigger.ramaC)
    //        {
    //            Debug.Log("Ya no se escucha...");
    //        }
    //    }
    //}
}
