using System.Threading.Tasks;
using FishNet.Object;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : NetworkBehaviour
{
    [SerializeField]
    private Application _application;
    
    [SerializeField]
    private GameObject _camera;

    [SerializeField]
    private GameObject _cam;

    [SerializeField]
    private float _moveSpeed;

    [SerializeField]
    private float _mouseSensitivity = 1;

    [SerializeField]
    private float _dashSpeed;

    [SerializeField]
    private int _dashTimeMilliseconds;

    [SerializeField]
    private float _dashCooldown;

    private Rigidbody _body;
    private InputManager _inputManager;

    private Vector3 _currentMoveVelocity;
    private Vector3 _dashDirection;
    private Vector2 _moveInput;
    private bool _isDashActive;
    private bool _canDash;
    private float _elaspedDashCooldownTime;
    
    [SerializeField]
    private bool _clientAuth = true;
    
    private void Awake()
    {
        _application = FindObjectOfType<Application>();
        _inputManager = _application.InputManager;
        _body = GetComponent<Rigidbody>();
    }
    
    public override void OnStartClient()
    {
        if (base.IsOwner)
            _camera.SetActive(true);
    }


    // Update is called once per frame
    void Update()
    {
        if (_inputManager == null)
        {
            _inputManager = _application.InputManager;
        }
        if (!base.IsOwner)
            return;
        
        _moveInput = _inputManager.Move();

        _currentMoveVelocity = Vector3.zero;

        //if (_inputManager.Dash() && _canDash && !_isDashActive)
        //{
        //    _activateDash();
        //}
        //if (!_canDash)
        //{
        //    _runCooldownTimer();
        //}
//
        //if (_isDashActive)
        //{
        //    _applyDashVelocity();
        //}

        if (_clientAuth)
            Move();
        else
            ServerMove();
        
    }

        _rotatePlayer();

        _body.velocity = _currentMoveVelocity;
    }

    private void ServerMove()
    {
        Move();
    }

    private void _applyMoveVelocity()
    {
        _currentMoveVelocity += transform.rotation * (new Vector3(_moveInput.x, 0, _moveInput.y) * _moveSpeed);
    }

    private void _applyDashVelocity()
    {
        _currentMoveVelocity += transform.rotation * (_dashDirection * _dashSpeed);
    }
   
    private void _rotatePlayer()
    {
        transform.forward = _cam.transform.forward;
    }

    private void _activateDash()
    {
        Task.Run(_dash);
    }

    private void _runCooldownTimer()
    {
        if (_elaspedDashCooldownTime >= _dashCooldown)
        {
            _canDash = true;
            _elaspedDashCooldownTime = 0;
        }

        _elaspedDashCooldownTime += Time.deltaTime;
    }

    private async Task _dash()
    {
        _isDashActive = true;
        _dashDirection = new Vector3(_moveInput.x, 0, _moveInput.y);

        await Task.Delay(_dashTimeMilliseconds);

        _isDashActive = false;
        _canDash = false;
    }
}
