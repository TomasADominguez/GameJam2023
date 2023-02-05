using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manos : MonoBehaviour
{
    public GameObject child;

    void Update()
    {
        if (this.gameObject.transform.childCount >= 1)
        {
            child = GetComponentInChildren<Pickable>().gameObject;
            child.GetComponent<Collider>().enabled = false;
        }
    }
}
