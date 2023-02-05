using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickable : MonoBehaviour
{
    [SerializeField] public int id;

    Transform posIncial;

    public void PosIncial()
    {
        Debug.Log("PosInical");
        posIncial = gameObject.transform;
        Debug.Log("Incial: " + posIncial.position);
    }

    public void Volver()
    {
        Debug.Log("Volver");
        gameObject.transform.parent = null;

        gameObject.transform.position = posIncial.position;
        gameObject.transform.rotation = posIncial.rotation;
        
        Debug.Log("Actual: " + gameObject.transform.position);
    }
}
