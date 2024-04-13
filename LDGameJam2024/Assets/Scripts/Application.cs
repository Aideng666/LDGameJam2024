using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Application : MonoBehaviour
{
    [SerializeField] InputActionAsset _gamecontrols;
    public InputManager InputManager { get; private set; }

    private void Awake()
    {
        InputManager = new InputManager(_gamecontrols);
    }
}
