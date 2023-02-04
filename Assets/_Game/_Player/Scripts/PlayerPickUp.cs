using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickUp : MonoBehaviour
{
    [SerializeField] private Transform hands;

    private CharacterMovement characterMovement;
    private Manos manos;

    void PickUp(GameObject objeto)
    {
        objeto.transform.position = hands.position;
        objeto.transform.rotation = hands.rotation;

        objeto.transform.SetParent(hands);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Objeto"))
        {
            if (hands.TryGetComponent<Manos>(out manos))
            {
                if (manos.agarrando == false)
                {
                    PickUp(GetComponent<Collider>().gameObject);
                    characterMovement.isPlayerCarryingObject = true;
                }
            }
        }
    }
}
