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

    private Animator playerAni;

    //private float carryingObject, startRunning;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        rb = GetComponent<Rigidbody>();
        playerAni = GetComponent<Animator>();

        characterController = new CharacterController();
        characterController.Player.Enable();

        //carryingObject = 0f;
        //startRunning = 0f;
    }

    private void Update()
    {
        //playerAni.SetFloat("CarryingObject", Mathf.Lerp(playerAni.GetFloat("CarryingObject"), carryingObject, .2f));
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
            //carryingObject = 1f;
            playerAni.SetFloat("CarryingObject", 1f);
        }
        else
        {
            rb.AddForce(new Vector3(currentInputVector.x, currentInputVector.y, 0f) * movementSpeed);
            //carryingObject = 0f;
            playerAni.SetFloat("CarryingObject", 0f);
        }

        if(inputVector == Vector2.zero)
        {
            playerAni.SetFloat("StartRunning", 0f);
        }
        else
        {
            playerAni.SetFloat("StartRunning", 1f);
        }
    }
}
