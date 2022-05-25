using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header ("Dependencies")]
    [SerializeField] private GameObject _player;

    [Header("Debugging")]
    [SerializeField] private Logger _logger;

    private Vector3 _initialPosition;
    private Vector3 _offset;
    private Vector3 _finalPosition;
    void Start()
    {
        _initialPosition = this.transform.position;
        _offset = new Vector3(_initialPosition.x - _player.transform.position.x, _initialPosition.y, _initialPosition.z - _player.transform.position.z);
    }

    void Update()
    {
        if (_player != null) MoveCamera(); 
        else Log("There's no player attached");
    }

    void MoveCamera()
    {
        _finalPosition = _player.transform.position + _offset;
        this.transform.position = _finalPosition;
    }

    void Log(object message)
    {
        if (_logger)
        {
            _logger.Log(message, this);
        }
    }
}
