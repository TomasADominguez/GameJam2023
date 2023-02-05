using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickUp : MonoBehaviour
{
    [SerializeField] private Transform hands;

    private CharacterMovement characterMovement;
    private Manos manos;

    public AudioSource aSourceIncorrecto;

    public Pickable pickable;

    private void Awake()
    {
        characterMovement = GetComponent<CharacterMovement>();
        manos = GetComponentInChildren<Manos>();
        //pickable = GetComponentInChildren<Pickable>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Objeto"))
        {
            if (hands.TryGetComponent<Manos>(out manos))
            {
                if (!characterMovement.isPlayerCarryingObject)
                {
                    StartCoroutine(PickUp(other.gameObject));
                }
            }
        }

        if (other.CompareTag("Goal"))
        {
            if (GetComponentInChildren<Pickable>() == null)
            {
                return;
            }
            if (characterMovement.isPlayerCarryingObject && 
                    other.GetComponent<CheckRightObject>().id == GetComponentInChildren<Pickable>().id)
            {
                StartCoroutine(Drop(manos.child, other.transform));
                other.GetComponent<CheckRightObject>().PlayParticles();
                other.GetComponent<SonidoPickUp>().Transicionar();
                other.GetComponent<SonidoPickUp>().ActivarSonido();
            }
            else if (!characterMovement.isPlayerCarryingObject && 
                    other.GetComponent<CheckRightObject>().id != GetComponentInChildren<Pickable>().id)
            {
                if(other.GetComponentInChildren<Pickable>().gameObject == null) return;
                StartCoroutine(PickUp(other.GetComponentInChildren<Pickable>().gameObject));
            }

            else if (characterMovement.isPlayerCarryingObject && 
                    other.GetComponent<CheckRightObject>().id != GetComponentInChildren<Pickable>().id)
                    {
                        aSourceIncorrecto.Play();
                        GetComponentInChildren<Pickable>().Volver();
                    }
        }
    }

    IEnumerator PickUp(GameObject pickedUpObject)
    {
        LeanTween.scale(pickedUpObject, Vector3.zero, .3f);

        yield return new WaitForSeconds(.5f);

        pickedUpObject.transform.position = hands.position;
        pickedUpObject.transform.rotation = hands.rotation;

        pickedUpObject.transform.SetParent(hands);

        LeanTween.scale(pickedUpObject, Vector3.one, .3f);

        characterMovement.isPlayerCarryingObject = true;
    }

    IEnumerator Drop(GameObject pickedUpObject, Transform newParent)
    {
        LeanTween.scale(pickedUpObject, Vector3.zero, .3f);

        yield return new WaitForSeconds(.5f);

        pickedUpObject.transform.position = newParent.transform.position;
        pickedUpObject.transform.rotation = newParent.transform.rotation;

        pickedUpObject.transform.SetParent(newParent);

        LeanTween.scale(pickedUpObject, Vector3.one, .3f);

        characterMovement.isPlayerCarryingObject = false;
    }
}
