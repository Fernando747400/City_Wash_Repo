using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header ("Dependencies")]
    [SerializeField] private GameObject _player;

    [Header("Debugging")]
    [SerializeField] private Logger _logger;

    private Vector3 _initialPotiton;
    private Vector3 _offset;
    void Start()
    {
        _initialPotiton = this.transform.position;
    }

    void Update()
    {
        if (_player != null) MoveCamera(); 
        else Log("There's no player attached");
    }

    void MoveCamera()
    {
        _offset = new Vector3(_player.transform.position.x, _initialPotiton.y, _player.transform.position.z + _initialPotiton.z);
        this.transform.position = _offset;
    }

    void Log(object message)
    {
        if (_logger)
        {
            _logger.Log(message, this);
        }
    }
}
