using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class BranchCameraChange : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera branchCam;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            branchCam.m_Priority = 11;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            branchCam.m_Priority = 1;
        }
        GetComponent<BoxCollider>().enabled = false;
    }
}
