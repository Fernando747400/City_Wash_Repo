using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Dependencies")]
    [SerializeField] private CharacterController _controller;
    [SerializeField] private FixedJoystick _joystick;

    [Header("Settings")]
    [SerializeField] private float _speed;

    [Header("Debugging")]
    [SerializeField] private Logger _logger;

    private Vector3 _direction = new Vector3();

    private void Update()
    {
        CalculateDirection();
    }

    private void FixedUpdate()
    {
        _controller.Move(_direction);
    }

    private void CalculateDirection()
    {
        _direction.z = _joystick.Direction.y;
        _direction.x = _joystick.Direction.x;
        _direction.y = 0f;
        _direction.Normalize();
        Log("My direction vector normalized " + _direction);
        _direction = _direction * Time.deltaTime * _speed;
        Log("My final vector values " + _direction);

        if (!_controller.isGrounded)
        {
            _direction += Physics.gravity;
        }
    }

    void Log(object message)
    {
        if (_logger)
        {
            _logger.Log(message, this);
        }
    }
}
