using System;
using System.Collections;
using System.Collections.Generic;
using GTC_Scripts;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BPuzzle : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;
    public string Interactionprompt => _prompt;

    [SerializeField] public BPuzzleNumber[] puzzleComponents;
    private int puzzleComponentIndex = 0; 

    public FollowPlayerCamera cameraScript;
    public SerialController serialController;
    public KeyboardMovement keyboardMovementScript;
    public bool keyboardActive = false;
    public BPuzzleNumber[] getBPuzzleComponents()
    {
        return puzzleComponents;
    }
    public bool Interact(Interactor interactor)
    {
        Debug.Log("Interacting with BPuzzle");
        if(cameraScript != null) cameraScript.ToggleCameraFollow();
        // movementScript und camerascript toggle
        if(!keyboardActive) serialController.ToggleMovmentAndRotation();
        if (keyboardActive) keyboardMovementScript.ToggleKeyboardMovement();
        ActivateCurrentPuzzleComponent();
        return true;
    }

    public void ToggleCameraFollowAndMovement()
    {
        cameraScript.ToggleCameraFollow();
        if(!keyboardActive) serialController.ToggleMovmentAndRotation();
        if (keyboardActive) keyboardMovementScript.ToggleKeyboardMovement();
    }
    public void ActivateCurrentPuzzleComponent()
    {
        if (puzzleComponents != null )
        {
            Debug.Log("activated puzzle component");
            BPuzzleNumber selectedComponent = puzzleComponents[puzzleComponentIndex];
            selectedComponent.ShowBorder();
        }
    }
    
    void Start()
    {
        if(!keyboardActive) serialController.OnPuzzleInput += ShowBorderOfCurrentSelection;
        if (keyboardActive) keyboardMovementScript.OnPuzzleInput += ShowBorderOfCurrentSelection;
    }
    
    void ShowBorderOfCurrentSelection(int index, bool change)
    {
        
        if (index != 0)
        {
            if (puzzleComponentIndex < puzzleComponents.Length - 1 && index > 0)
            {
                BPuzzleNumber selectedComponent = puzzleComponents[puzzleComponentIndex];
                selectedComponent.HideBorder();
                puzzleComponentIndex += index;
                BPuzzleNumber newSelectedComponent = puzzleComponents[puzzleComponentIndex];
                newSelectedComponent.ShowBorder();
            }
            if (puzzleComponentIndex > 0 && index < 0)
            {
                BPuzzleNumber selectedComponent = puzzleComponents[puzzleComponentIndex];
                selectedComponent.HideBorder();
                puzzleComponentIndex += index;
                BPuzzleNumber newSelectedComponent = puzzleComponents[puzzleComponentIndex];
                newSelectedComponent.ShowBorder();
            }
        }

        //return taste aus dem Spiel
        if (change && puzzleComponentIndex >= puzzleComponents.Length - 1 && !_isCooldownActive)
        {
            cameraScript.ToggleCameraFollow();
            if(!keyboardActive)serialController.ToggleMovmentAndRotation();
            if(keyboardActive)keyboardMovementScript.ToggleKeyboardMovement();
        }
        
        if (change && puzzleComponentIndex < puzzleComponents.Length - 1 )
        {
            BPuzzleNumber selectedComponent = puzzleComponents[puzzleComponentIndex];
            selectedComponent.ChangeNumber();
        }
    }
    
    
    private bool _isCooldownActive = false;
    IEnumerator ActivateCooldown()
    {
        _isCooldownActive = true;
        yield return new WaitForSeconds(1f);
        _isCooldownActive = false;
    }
    
}
