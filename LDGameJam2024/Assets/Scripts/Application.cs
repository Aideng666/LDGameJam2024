using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Application : MonoBehaviour
{
    [SerializeField] InputActionAsset _gamecontrols;

    private InputManager _inputManager;

    private void Awake()
    {
        _inputManager = new InputManager(_gamecontrols);
    }
}
