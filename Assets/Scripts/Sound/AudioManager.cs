using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioPlayer backgroundMusic;
    public AudioPlayer coffeeAndCupPlayer;
    public AudioPlayer cardPlayer;
    public AudioPlayer doorOpen;
    public AudioPlayer doorClose;
    public AudioPlayer keyCardAccept;
    public AudioPlayer keyCardReject;
    public AudioPlayer coffeeFail;
    public AudioPlayer coffeeSuccess;

    public void Start()
    {
        backgroundMusic.playSound();
    }

    public void playSound(SoundEnum sound)
    {
        switch (sound)
        {
            case SoundEnum.PickupOne:
                coffeeAndCupPlayer.playSound();
                break;
            case SoundEnum.PickupTwo:
                cardPlayer.playSound();
                break;
            case SoundEnum.DoorOpen:
                doorOpen.playSound();
                break;
            case SoundEnum.DoorClose:
                doorClose.playSound();
                break;
            case SoundEnum.KeyCardAccept:
                keyCardAccept.playSound();
                break;
            case SoundEnum.KeyCardReject:
                keyCardReject.playSound();
                break;
            case SoundEnum.CoffeeFail:
                coffeeFail.playSound();
                break;
            case SoundEnum.CoffeeSuccess:
                coffeeSuccess.playSound();
                break;
        }
    }
}
