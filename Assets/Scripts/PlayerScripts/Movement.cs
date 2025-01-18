using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]
    float moveSpeed;
    [SerializeField]
    float rotationSpeed;
    Rigidbody rb;
    [SerializeField]
    bool controllerEnabled;
    private Vector3 input;

    void Start()
    {
        input = new Vector3();
        rb = GetComponent<Rigidbody>();
        SerialController serialController = FindObjectOfType<SerialController>();
        if (serialController != null && controllerEnabled)
        {
            serialController.OnMovementInput += (controllerInput) =>
            {
                input = controllerInput; 
                //Debug.Log("Event received with input: " + input);
            };
        }
        
        KeyboardMovement keyboardMovement = FindObjectOfType<KeyboardMovement>();
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
        //Debug.Log("Movement going on " + input);
        Vector3 movement = ((transform.forward * -input.x) + (transform.right * input.z)).normalized * moveSpeed;
        rb.linearVelocity = new Vector3(movement.x, rb.linearVelocity.y, movement.z);
        
    }
}