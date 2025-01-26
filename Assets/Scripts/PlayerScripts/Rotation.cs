using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Rotation : MonoBehaviour
{
    [SerializeField] float rotationSpeed;
    Rigidbody rb;
    [SerializeField] bool controllerEnabled;
    private float rotationInput = 0f;
    
    void Start()
    {
        
        rb = GetComponent<Rigidbody>();
        SerialController serialController = FindFirstObjectByType<SerialController>();
        if (serialController != null)
        {
            serialController.OnRotationInput += (controllerInput) =>
            {
                rotationInput = controllerInput; 
                //Debug.Log("Event received with input: " + input);
            };
        }
        
        KeyboardMovement keyboardMovement = FindFirstObjectByType<KeyboardMovement>();
        if (!controllerEnabled)
        {
            keyboardMovement.OnRotationInput += keyboardInput =>
            {
                rotationInput = keyboardInput;
                Debug.Log("Rotation going on " + rotationInput);

            };
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        
        Rotate(rotationInput); 
    }
    
    void Rotate(float input)
    {
        float rotationAmount = input * rotationSpeed * Time.deltaTime;
        rb.transform.Rotate(0, rotationAmount, 0);
        //rb.transform.Rotate(0, rotationAmount, 0); 
    }
        
}

