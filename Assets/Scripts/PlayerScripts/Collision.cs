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
            case "Card":
                UIManager.updateCards(other.gameObject.name);
                break;
        }
        other.gameObject.SetActive(false);
    }
}
