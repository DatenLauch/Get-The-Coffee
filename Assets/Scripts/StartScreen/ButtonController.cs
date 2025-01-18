using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    
    public SerialController serialController;
    [SerializeField] public Button[] buttons;
    private int index = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        serialController.OnRotationInput += highLightButton;
    }

    // Update is called once per frame
    void Update()
    {
        serialController.OnInteractionInput += selectButton;
    }

    void highLightButton(float value)
    {
        if (value == 1f && index >= buttons.Length) index++;
        if (value == -1f && index != 0) index++;

        if (index == 0)
        {
            buttons[index].Select();
        }
    }

    void selectButton(bool value)
    {
        if (value) buttons[index].onClick.Invoke();
    }
}
