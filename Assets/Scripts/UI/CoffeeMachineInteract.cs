using EndScreen;
using UnityEngine;
using GTC_Scripts;

public class CoffeeMachineInteract : MonoBehaviour, IInteractable
{
    public UIManager UIManager;
    public AudioManager AudioManager;
    [SerializeField] private GameOverManager gameOverManager;
    public string Interactionprompt => "";
    public bool Interact(Interactor interactor)
    {
        if (UIManager.beans == UIManager.maxBeans && UIManager.cups == UIManager.maxCups)
        {
            AudioManager.playSound(SoundEnum.CoffeeSuccess);
            gameOverManager.EndGame(true, UIManager.totalTime);
            print("success coffee");
            return true;
        }
        AudioManager.playSound(SoundEnum.CoffeeFail);
        print("fail coffee");
        return true;
    }
}
