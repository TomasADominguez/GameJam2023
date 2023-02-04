using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed, inputSmoothSpeed, carryingObjectModifier;
    [SerializeField] private bool isPlayerCarryingObject;

    private PlayerInput playerInput;
    private CharacterController characterController;
    private Rigidbody rb;
    private Vector2 currentInputVector, currentVelocity;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();

        characterController = new CharacterController();
        characterController.Player.Enable();

        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        MoveCharacter();   
    }

    private void MoveCharacter()
    {
        Vector2 inputVector = characterController.Player.Movement.ReadValue<Vector2>();
        currentInputVector = Vector2.SmoothDamp(currentInputVector, inputVector, ref currentVelocity, inputSmoothSpeed);

        if (isPlayerCarryingObject)
        {
            rb.AddForce(new Vector3(currentInputVector.x, currentInputVector.y, 0f) * (movementSpeed * carryingObjectModifier));
        }
        else
        {
            rb.AddForce(new Vector3(currentInputVector.x, currentInputVector.y, 0f) * movementSpeed);
        }
    }
}
