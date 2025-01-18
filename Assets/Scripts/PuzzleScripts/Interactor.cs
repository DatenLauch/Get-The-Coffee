using System;
using System.Collections;
using System.Collections.Generic;
using GTC_Scripts;
using UnityEngine;
using UnityEngine.InputSystem;


public class Interactor : MonoBehaviour
{
    [SerializeField] private Transform _interactionPoint;
    [SerializeField] private float _interactionPointRadius = 0.5f;
    [SerializeField] private LayerMask _interactableMask;
    [SerializeField] private InteractionPromptUI _interactionPromptUI;

    private readonly Collider[] _colliders = new Collider[5];
    [SerializeField] private int _numFound;

    private IInteractable _interactable;
    bool interaction = false;
    private bool _isCooldownActive = false;
    private void Start()
    {
        
        SerialController serialController = FindObjectOfType<SerialController>();
        if (serialController != null)
        {
            serialController.OnInteractionInput += (interactionInput) =>
            {
                this.interaction = interactionInput; 
                Debug.Log("InteractionEvent received with input: " + interactionInput);
            };
        }
        
        KeyboardMovement keyboardMovement = FindObjectOfType<KeyboardMovement>();
        if (keyboardMovement != null)
        {
            keyboardMovement.OnInteractionInput += interactionInput =>
            {
                this.interaction = interactionInput;
                Debug.Log("InteractionEvent from Keyboard received with input: " + interactionInput);
            };
        }
    }

    private void Update()
    {
        // Returns the number of Objects found around the given Object
        _numFound = Physics.OverlapSphereNonAlloc(_interactionPoint.position, _interactionPointRadius, _colliders, _interactableMask);

        if (_numFound > 0)
        {
            _interactable = _colliders[0].GetComponent<IInteractable>();
            
            if (_interactable != null) 
            {
                if (!_interactionPromptUI.IsDisplayed) _interactionPromptUI.SetUp(_interactable.Interactionprompt);

                if (interaction && !_isCooldownActive)
                {
                    _interactable.Interact(this);
                    StartCoroutine(ActivateCooldown());
                    interaction = false;
                }
            }

        }
        else
        {
            if(_interactable != null) _interactable = null;
            if(_interactionPromptUI.IsDisplayed) _interactionPromptUI.Close();
        }

    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(_interactionPoint.position, _interactionPointRadius);
    }
    IEnumerator ActivateCooldown()
    {
        _isCooldownActive = true;
        yield return new WaitForSeconds(1f);
        _isCooldownActive = false;
    }
}
