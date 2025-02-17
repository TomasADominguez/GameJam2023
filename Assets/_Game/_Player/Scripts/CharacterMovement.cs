﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed, inputSmoothSpeed, carryingObjectModifier;
    [SerializeField] public bool isPlayerCarryingObject;

    private PlayerInput playerInput;
    private CharacterController characterController;
    private Rigidbody rb;
    private Vector2 currentInputVector, currentVelocity;

    private Animator playerAni;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        rb = GetComponent<Rigidbody>();
        playerAni = GetComponent<Animator>();

        characterController = new CharacterController();
        characterController.Player.Enable();
    }

    private void FixedUpdate()
    {
        MoveCharacter();
    }

    private void MoveCharacter()
    {
        Vector2 inputVector = characterController.Player.Movement.ReadValue<Vector2>();
        currentInputVector = Vector2.SmoothDamp(currentInputVector, inputVector, ref currentVelocity, inputSmoothSpeed);

        playerAni.SetFloat("StartRunning", rb.velocity.magnitude);
        playerAni.SetFloat("CarryingObject", rb.velocity.magnitude);

        if (isPlayerCarryingObject)
        {
            rb.AddForce(new Vector3(currentInputVector.x, currentInputVector.y, 0f) * (movementSpeed * carryingObjectModifier));
            playerAni.SetFloat("CarryingObject", 1f);
        }
        else
        {
            rb.AddForce(new Vector3(currentInputVector.x, currentInputVector.y, 0f) * movementSpeed);
            playerAni.SetFloat("CarryingObject", 0f);
        }

        if (rb.velocity.x > 0)
        {
            transform.rotation = Quaternion.Euler(0f, 90f, 0f);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0f, -90f, 0f);
        }

        if (rb.velocity.y > 0)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
        //else
        //{
        //    transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        //}

        if (inputVector == Vector2.zero)
        {
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        }
    }
}
