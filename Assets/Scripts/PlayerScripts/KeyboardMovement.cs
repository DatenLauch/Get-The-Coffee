using UnityEngine;

public class KeyboardMovement : MonoBehaviour
{
    
    public delegate void MovementInputHandler(Vector3 movementInput);
    public delegate void RotationInputHandler(float rotationInput);    
    public delegate void InteractionInputHandler(bool interaction);
    public delegate void PuzzleInputHandler(int puzzleIndexChange, bool interaction);
    public event PuzzleInputHandler OnPuzzleInput;

    public event InteractionInputHandler OnInteractionInput;
    public event RotationInputHandler OnRotationInput;
    public event MovementInputHandler OnMovementInput;
    
    private bool _movementEnabled = true;

    private bool _puzzleEnabled = false;

    // Update is called once per frame
    Vector3 _vector3 = new Vector3(0f, 0f, 0f);
    float _rotation;
    bool _interaction;
    void Update()
    {
        if(!_puzzleEnabled) Movement();
        if(_puzzleEnabled) PuzzleMovement();
    }

    void Movement()
    {
        if (!_movementEnabled) return;

        if (Input.GetKeyDown(KeyCode.W))
        {

            _vector3 = new Vector3(-1f, 0f, 0f);
            OnMovementInput?.Invoke(_vector3);
        }
        else if(Input.GetKeyUp(KeyCode.W))
        {
            _vector3 = new Vector3(0f, 0f, 0f);
            OnMovementInput?.Invoke(_vector3);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            _vector3 = new Vector3(1f, 0f, 0f);
            OnMovementInput?.Invoke(_vector3);
        }
        else if(Input.GetKeyUp(KeyCode.S))
        {
            _vector3 = new Vector3(0f, 0f, 0f);
            OnMovementInput?.Invoke(_vector3);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            OnRotationInput?.Invoke(-1f);
        }
        else if(Input.GetKeyUp(KeyCode.A))
        {
            OnRotationInput?.Invoke(0f);

        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            OnRotationInput?.Invoke(1f);
        }
        else if(Input.GetKeyUp(KeyCode.D))
        {
            OnRotationInput?.Invoke(0f);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            OnInteractionInput?.Invoke(interaction: true);
        }
        else if(Input.GetKeyDown(KeyCode.E))
        {
            OnInteractionInput?.Invoke(interaction: false);
        }
        
    }

    int indexChange = 0;
    void PuzzleMovement()
    {
        Debug.Log("PuzzleMovement");
        if (Input.GetKeyDown(KeyCode.A))
        {
            indexChange = -1;
            OnPuzzleInput?.Invoke(indexChange, _interaction);
        }
        else if(Input.GetKeyUp(KeyCode.A))
        {
            indexChange = 0;
            OnPuzzleInput?.Invoke(indexChange, _interaction);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            indexChange = 1;
            OnPuzzleInput?.Invoke(indexChange, _interaction);
        }
        else if(Input.GetKeyUp(KeyCode.D))
        {
            indexChange = 0;
            OnPuzzleInput?.Invoke(indexChange, _interaction);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            _interaction = true;
            OnPuzzleInput?.Invoke(indexChange, _interaction);
        }
        else if(Input.GetKeyUp(KeyCode.E))
        {
            _interaction = false;
            OnPuzzleInput?.Invoke(indexChange, _interaction);
        }
    }
    
    /** Disable the movement with the keyboard.
     * Example: Game is over and the player should not be able to move.
     */
    public void DisableKeyboardMovement()
    {
        _movementEnabled = false;
    }

    public void ToggleKeyboardMovement()
    {
        _movementEnabled = !_movementEnabled;
        _puzzleEnabled = !_puzzleEnabled;
    }
}
