using System;
using GTC_Scripts;
using UnityEngine;

public class KeyCardTrigger : MonoBehaviour, IInteractable
{
    public string Interactionprompt { get; }
    [SerializeField] private string keyCardID;
    public SerialController serialController;
    public bool correctKeyCard = false;
    [SerializeField] private UIManager uiManager;
    //[SerializeField] private DoorTrigger doorTrigger;
    [SerializeField] private AudioManager audioManager;
    private bool doorOpen = false;
    private Animator doorAnimator;
    
    void Start()
    {
        doorAnimator = GetComponent<Animator>();
    }

    private void OnTriggerStay(Collider other)
    {

        if (other is CapsuleCollider)
        {
            serialController.OnCardReadInput += CheckKeyCard;
        }
    }

    public bool Interact(Interactor interactor)
    {
        Debug.Log("KeyCardTrigger Interact: "+ correctKeyCard + "   " + uiManager.hasBlueCard + "   " + uiManager.hasRedCard + "   " + uiManager.hasRedCard);
        if (correctKeyCard)
        {
            Debug.Log("KeyCardTrigger Interact Open Door");
            OpenDoor();
        }
        else
        {
            audioManager.playSound(SoundEnum.KeyCardReject);
        }
        return true;
    }

    public void CheckKeyCard(string givenKeyCardID)
    {
        correctKeyCard = keyCardID.Equals(givenKeyCardID);
        SoundEnum soundEnum = this.keyCardID.Equals(givenKeyCardID) ? SoundEnum.KeyCardAccept : SoundEnum.KeyCardReject;
        audioManager.playSound(soundEnum);
        
    }
    
    public void OpenDoor()
    {
        //
        doorAnimator.SetTrigger("ToggleDoor");
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
    }
}