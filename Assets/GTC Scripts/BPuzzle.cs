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

    private bool number;

    [SerializeField] public BPuzzleNumber[] puzzleComponents;
    private int puzzleComponentIndex = 0; 

    public FollowPlayerCamera cameraScript;
    public SerialController serialController;

    public BPuzzleNumber[] getBPuzzleComponents()
    {
        return puzzleComponents;
    }
    public bool Interact(Interactor interactor)
    {
        Debug.Log("Interacting with BPuzzle");
        if(cameraScript != null) cameraScript.ToggleCameraFollow();
        // movementScript und camerascript toggle
        serialController.ToggleMovmentAndRotation();
        ActivateCurrentPuzzleComponent();
        return true;
    }

    public void ToggleCameraFollowAndMovement()
    {
        cameraScript.ToggleCameraFollow();
        serialController.ToggleMovmentAndRotation();
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
        serialController.OnPuzzleInput += ShowBorderOfCurrentSelection;

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
            serialController.ToggleMovmentAndRotation();
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
