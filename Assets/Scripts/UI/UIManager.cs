using UnityEngine;
using TMPro;
using System.Collections;

public class UIManager : MonoBehaviour
{
  [SerializeField]
  public TextMeshProUGUI timer;
  public TextMeshProUGUI beansUI;
  public TextMeshProUGUI cupsUI;
  public GameObject BlueCard;
  public GameObject RedCard;
  public GameObject YellowCard;
  public int cups;
  public int beans;
  public bool hasRedCard = false;
  public bool hasBlueCard = false;
  public bool hasYellowCard = false;
  public float totalTime;

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
    beansUI.text = $"       :{beans}";
  }

  public void increaseCups()
  {
    this.cups++;
    cupsUI.text = $"       :{cups}";
  }

  public void updateCards(string cardColor)
  {
    switch (cardColor)
    {
      case "red":
        hasRedCard = true;
        break;
      case "blue":
        hasBlueCard = true;
        break;
      case "yellow":
        hasYellowCard = true;
        break;
    }
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
  }
}
