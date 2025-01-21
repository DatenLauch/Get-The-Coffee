using UnityEngine;

public class FirstPersonMovement : MonoBehaviour
{
    public Rigidbody Player;
    public float Speed;
    public float Sensitivity;
    public float JumpForce;

    private Vector3 playerMovementInput;
    private Vector2 playerMouseInput;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
    }

    void FixedUpdate()
    {
        playerMovementInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
        playerMouseInput = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

        movePlayer();
    }


    private void playerInput()
    {
    }

    private void movePlayer()
    {
        Vector3 moveVector = transform.TransformDirection(playerMovementInput) * Speed;
        Player.linearVelocity = new Vector3(moveVector.x, Player.linearVelocity.y, moveVector.z);
    }
}
