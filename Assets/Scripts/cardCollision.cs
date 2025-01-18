using UnityEngine;

public class cardCollsion : MonoBehaviour
{
    public UIManager uiManager;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Destroy(this.gameObject);
            uiManager.updateKeys("red");
        }
    }
}
