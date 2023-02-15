using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickable : MonoBehaviour
{
    [SerializeField] public int id;

    Transform posIncial;

    public Vector3 pos;
    public Vector3 rot;
    public Vector3 scale;

    void Start()
    {
        Debug.Log("PosInical");
        posIncial = gameObject.transform;
        Debug.Log("Incial: " + posIncial.position);
    }

    public void Volver()
    {
        Debug.Log("Volver");
        gameObject.transform.parent = null;

        gameObject.transform.position = pos;
        //gameObject.transform.rotation = rot;
        gameObject.transform.localScale = scale;

        //gameObject.transform.position = posIncial.position;
        //gameObject.transform.rotation = posIncial.rotation;
        
        Debug.Log("Actual: " + gameObject.transform.position);
    }
}
