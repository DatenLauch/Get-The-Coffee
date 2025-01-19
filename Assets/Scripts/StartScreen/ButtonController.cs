using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    
    public SerialController serialController;
    [SerializeField] public Button[] buttons;
    private  int index = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        highLightButton(0);
        serialController.OnMovementInput += handleRotationInput;
        serialController.OnInteractionInput += selectButton;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    

    void highLightButton(int index)
    {
        if(index >= buttons.Length) return;
        Debug.Log("highLightButton highlighting button at: " + index );
        buttons[index].Select();
    }
    void handleRotationInput(Vector3 vector3)
    {
        int value = Mathf.RoundToInt(vector3.x);
        Debug.Log("value got from controller : " + value);
        if(value == 0) return;
        if(value == -1 && index == 0) return;
        
        if (value == 1 && index < buttons.Length)
        {
            index += 1;
            highLightButton(index);
        };
        if (value == -1 && index > 0)
        {
            index -= 1;
            highLightButton(index);
        }
        
    }

    void selectButton(bool value)
    {
        if (value) Debug.Log("button selected: "+ index);
        if (value) buttons[index].onClick.Invoke();
    }
}
