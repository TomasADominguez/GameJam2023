using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FamilyCheck : MonoBehaviour
{
    [SerializeField] private GameObject[] portraits;
    [SerializeField] private GameObject goal;

    private void Update()
    {
        ChangePortrait();
    }

    private void ChangePortrait()
    {
        if (goal.GetComponent<CheckRightObject>().isCorrectObjectPlaced)
        {
            portraits[0].SetActive(false);
            portraits[1].SetActive(true);
        }
    }
}
