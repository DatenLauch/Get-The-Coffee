using UnityEngine;

public class cupCollision : MonoBehaviour
{
    public UIManager uiManager;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Destroy(this.gameObject);
            uiManager.increaseCups();
        }
    }
}
