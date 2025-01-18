using UnityEngine;

public class Collision : MonoBehaviour
{
    public UIManager UIManager;
    private void OnTriggerEnter(Collider other)
    {
        switch (other.gameObject.tag)
        {
            case "Bean":
                UIManager.increaseBeans();
                break;
            case "Cup":
                UIManager.increaseCups();
                break;
        }

        switch (other.gameObject.name)
        {
            case "BlueCard":
                UIManager.updateCards("blue");
                break;
            case "RedCard":
                UIManager.updateCards("red");
                break;
            case "YellowCard":
                UIManager.updateCards("yellow");
                break;
        }
        other.gameObject.SetActive(false);
    }
}
