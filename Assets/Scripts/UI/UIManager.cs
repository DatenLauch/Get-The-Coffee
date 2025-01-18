using UnityEngine;
using TMPro;
using System.Collections;

public class UIManager : MonoBehaviour
{
  [SerializeField]
  public TextMeshProUGUI timer;
  public TextMeshProUGUI beansUI;
  public TextMeshProUGUI cupsUI;
  public TextMeshProUGUI keysUI;
  public int cups;
  public int beans;
  public bool redCard = false;
  public bool blueCard = false;
  public bool greenCard = false;
  public float totalTime;

  void Start() { StartCoroutine(Countdown()); }

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

  public void updateKeys(string cardColor)
  {
    switch (cardColor)
    {
      case "red":
        redCard = true;
        break;
      case "blue":
        blueCard = true;
        break;
      case "green":
        greenCard = true;
        break;
    }
    keysUI.text = $"RedCard";
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
