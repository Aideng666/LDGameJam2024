using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager
{
    private InputActionAsset _controls;
    private InputActionMap _actionMap;

    //To add more controls just add more InputActions here
    //Initialize them the same way that _moveInput is in Init()
    //Then make a function to return that actions input
    private InputAction _moveInput;
    private InputAction _dashInput;

    public InputManager(InputActionAsset controls)
    {
        _controls = controls;

        _actionMap = _controls.FindActionMap("Player");
        _actionMap.Enable();

        _moveInput = _actionMap.FindAction("Move");
        _dashInput = _actionMap.FindAction("Dash");
    }

    public Vector2 Move()
    {
        return _moveInput.ReadValue<Vector2>();
    }

    public bool Dash()
    {
        return _dashInput.triggered;
    }
}
