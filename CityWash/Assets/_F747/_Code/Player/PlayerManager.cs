using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [Header("Dependencies")]
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private GameObject _player;

    [Header("Settings")]
    [SerializeField] private bool _DevMode;
    [SerializeField] private float _speed;
    [SerializeField] private float _scale;

    [Header("Debugging")]
    [SerializeField] private Logger _logger;

    private void Start()
    {
        _playerMovement.Speed = _speed;
    }

    public void UpdateValues()
    {
        if (!_DevMode)
        {
            _playerMovement.Speed = PlayerPrefs.GetFloat("Player_speed");
            float tempScale = PlayerPrefs.GetFloat("Player_scale");
            _player.transform.localScale = new Vector3(tempScale, tempScale, tempScale);
        }
        else
        {
            _playerMovement.Speed = _speed;
            _player.transform.localScale = new Vector3(_scale,_scale,_scale);
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
