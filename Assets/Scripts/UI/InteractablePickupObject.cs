using UnityEngine;
using GTC_Scripts;

public class InteractablePickupObject : MonoBehaviour, IInteractable
{
    public GameObject prompt;
    public UIManager uIManager;
    public string Interactionprompt => "";

    public bool Interact(Interactor Interactor)
    {
        switch (gameObject.tag)
        {
            case "Bean":
                uIManager.increaseBeans();
                destroyInteractable();
                break;
            case "Cup":
                uIManager.increaseCups();
                destroyInteractable();
                break;
            case "Card":
                uIManager.updateCards(gameObject.name);
                destroyInteractable();
                break;
        }
        return true;
    }
    private void destroyInteractable()
    {
        Destroy(gameObject);
        prompt.SetActive(false);
    }
}
