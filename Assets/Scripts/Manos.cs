using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manos : MonoBehaviour
{
    public bool agarrando;
    public GameObject hijo;

    void Update()
    {
        if (this.gameObject.transform.childCount >= 1)
        {
            agarrando = true;
            hijo = GetComponentInChildren<Pickable>().gameObject;

            hijo.GetComponent<Collider>().enabled = false;
        }
        else
        {
            agarrando = false;
        }
    }
}
