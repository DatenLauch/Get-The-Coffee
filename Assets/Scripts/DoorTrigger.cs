using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    private Animator doorAnimator;

    void Start()
    {
        doorAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            Debug.Log("Open Door");
            doorAnimator.SetTrigger("ToggleDoor");
        }
    }
}