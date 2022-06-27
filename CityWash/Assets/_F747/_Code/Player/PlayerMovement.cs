using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Dependencies")]
    [SerializeField] private CharacterController _controller;
    [SerializeField] private FixedJoystick _joystick;
    [SerializeField] private string _dirtTag;

    [Header("Debugging")]
    [SerializeField] private Logger _logger;

    [HideInInspector] public float Speed;

    private Vector3 _direction = new Vector3();
    private bool _isPaused = true;

    private void Update()
    {
         CalculateDirection();
    }

    private void FixedUpdate()
    {
        if(!_isPaused) _controller.Move(_direction);
    }

    private void CalculateDirection()
    {
        _direction.z = _joystick.Direction.y;
        _direction.x = _joystick.Direction.x;
        _direction.y = 0f;
        _direction.Normalize();
        Log("My direction vector normalized " + _direction);
        _direction = _direction * Time.deltaTime * Speed;
        Log("My final vector values " + _direction);

        if (!_controller.isGrounded)
        {
            _direction += Physics.gravity;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(_dirtTag))
        {
            other.GetComponent<Dirt>().CleanDirt();
        }
    }

    public void PausePlayer() => _isPaused = true;
    public void UnpausePlayer() => _isPaused = false;

    void Log(object message)
    {
        if (_logger)
        {
            _logger.Log(message, this);
        }
    }
}
