using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;
using EndScreen;

public class UIManager : MonoBehaviour
{
  [SerializeField]
  public TextMeshProUGUI timer;
  public TextMeshProUGUI beansUI;
  public TextMeshProUGUI cupsUI;
  public GameObject BlueCard;
  public GameObject RedCard;
  public GameObject YellowCard;
  public AudioManager audioManager;
  public int cups = 0;
  public int beans = 0;
  public int maxCups = 1;
  public int maxBeans = 5;
  public bool hasRedCard = false;
  public bool hasBlueCard = false;
  public bool hasYellowCard = false;
  public float totalTime;
  
  [SerializeField] private GameOverManager gameOverManager;


  void Start() { StartCoroutine(Countdown()); }

  void Update()
  {
    if (hasRedCard && !RedCard.activeInHierarchy)
    {
      RedCard.SetActive(true);
    }
    if (!hasRedCard && RedCard.activeInHierarchy)
    {
      RedCard.SetActive(false);
    }
    if (hasBlueCard && !BlueCard.activeInHierarchy)
    {
      BlueCard.SetActive(true);
    }
    if (!hasBlueCard && BlueCard.activeInHierarchy)
    {
      BlueCard.SetActive(false);
    }
    if (hasYellowCard && !YellowCard.activeInHierarchy)
    {
      YellowCard.SetActive(true);
    }
    if (!hasYellowCard && YellowCard.activeInHierarchy)
    {
      YellowCard.SetActive(false);
    }
  }

  public void increaseBeans()
  {
    this.beans++;
    beansUI.text = $"       {beans} / {maxBeans}";
    audioManager.playSound(SoundEnum.PickupOne);
  }

  public void increaseCups()
  {
    this.cups++;
    cupsUI.text = $"       {cups} / {maxCups}";
    audioManager.playSound(SoundEnum.PickupOne);
  }

  public void updateCards(string cardColor)
  {
    switch (cardColor)
    {
      case "RedCard":
        hasRedCard = true;
        break;
      case "BlueCard":
        hasBlueCard = true;
        break;
      case "YellowCard":
        hasYellowCard = true;
        break;
    }
    audioManager.playSound(SoundEnum.PickupTwo);
  }

  void UpdateTextField()
  {
    int minutes = Mathf.FloorToInt(totalTime / 60f);
    int seconds = Mathf.RoundToInt(totalTime % 60f);

    string minutesText = minutes.ToString("00");
    string secondsText = seconds.ToString("00");

    timer.text = $"{minutesText} : {secondsText}";
  }

  IEnumerator Countdown()
  {
    while (totalTime > 0)
    {
      totalTime -= 1.0f;
      UpdateTextField();
      yield return new WaitForSecondsRealtime(1.0f);
    }
    gameOverManager.EndGame(false, totalTime);
  }
}
