using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    private Rigidbody rb;
    [SerializeField] bool controllerEnabled;
    private Vector3 input;
    
    private bool _movementEnabled = true;

    void Start()
    {
        input = new Vector3();
        rb = GetComponent<Rigidbody>();
        SerialController serialController = FindFirstObjectByType<SerialController>();
        if (serialController != null && controllerEnabled)
        {
            serialController.OnMovementInput += (controllerInput) =>
            {
                input = controllerInput; 
                //Debug.Log("Event received with input: " + input);
            };
        }
        
        KeyboardMovement keyboardMovement = FindFirstObjectByType<KeyboardMovement>();
        if (!controllerEnabled)
        {
            keyboardMovement.OnMovementInput += controllerInput =>
            {
                input = controllerInput;
                Debug.Log("Movement going on " + input);
            };
        }
    }

    // Update is called once per frame
    void Update()
    {
        /*if (!controllerEnabled)
        {
            // Raw for now because of no smoothing (better for keyboard), for Arduino maybe without raw.
            input = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
        }*/
        Move(input);
    }
    

    void Move(Vector3 input)
    {
        if (!_movementEnabled) return;
        
        //Debug.Log("Movement going on " + input);
        Vector3 movement = ((transform.forward * -input.x) + (transform.right * input.z)).normalized * moveSpeed;
        rb.linearVelocity = new Vector3(movement.x, rb.linearVelocity.y, movement.z);
        
    }

    /** Disable the movement with the arduino.
     * Example: Game is over and the player should not be able to move.
     */
    public void DisableArduinoMovement()
    {
        _movementEnabled = false;
    }
}