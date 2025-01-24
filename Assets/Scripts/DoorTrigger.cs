using GTC_Scripts;
using UnityEngine;

public class DoorTrigger : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;
    public string Interactionprompt => _prompt;
    public AudioManager audioManager;
    private Animator doorAnimator;
    private bool doorOpen = false;

    public bool Interact(Interactor interactor)
    {
        OpenDoor();
        if (!doorOpen)
        {
            audioManager.playSound(SoundEnum.DoorOpen);
            doorOpen = true;
        }
        else
        {
            audioManager.playSound(SoundEnum.DoorClose);
            doorOpen = false;
        }

        return true;
    }

    void Start()
    {
        doorAnimator = GetComponent<Animator>();
    }

    public void OpenDoor()
    {
        //
        doorAnimator.SetTrigger("ToggleDoor");
    }
}
