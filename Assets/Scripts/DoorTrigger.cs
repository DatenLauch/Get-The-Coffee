using GTC_Scripts;
using UnityEngine;

public class DoorTrigger : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;
    public string Interactionprompt => _prompt;
    
    private Animator doorAnimator;
    public bool Interact(Interactor interactor)
    {
        OpenDoor();
        return true;
    }

    void Start()
    {
        doorAnimator = GetComponent<Animator>();
    }
    
    public void OpenDoor()
    {
        doorAnimator.SetTrigger("ToggleDoor");
    }
}
