using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckRightObject : MonoBehaviour
{
    [SerializeField] public int id;
    [SerializeField] private ParticleSystem stars;

    public bool isCorrectObjectPlaced;

    public void PlayParticles()
    {
        if (stars == null)
        {
            return;
        }
        stars.Play();
        isCorrectObjectPlaced = true;
    }

}
