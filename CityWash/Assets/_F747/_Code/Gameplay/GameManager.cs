using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Debugging")]
    [SerializeField] private Logger _logger;

    public static GameManager current;

    public void Awake()
    {
        current = this;
        //DontDestroyOnLoad(this.gameObject);

        Application.targetFrameRate = 60;
    }

    [Header("Events")]

    [SerializeField] private UnityEvent _startGame;
    public void StartGame() => _startGame?.Invoke();

    [SerializeField] private UnityEvent _endGame;
    public void EndGame() => _endGame?.Invoke();

    [SerializeField] private UnityEvent _pauseGame;
    public void PauseGame() => _pauseGame?.Invoke();

    [SerializeField] private UnityEvent _unpauseGame;
    public void UnpauseGame() => _unpauseGame?.Invoke();

    [SerializeField] private UnityEvent _countPoint;
    public void CountPoint() => _countPoint?.Invoke();

    [SerializeField] private UnityEvent _winGame;
    public void WinGame() => _winGame?.Invoke();

    [SerializeField] private UnityEvent _lostGame;
    public void LostGame() => _lostGame?.Invoke();

    public void ResetScene()
    {
        SceneManager.LoadScene(0);
    }

    void Log(object message)
    {
        if (_logger)
        {
            _logger.Log(message, this);
        }
    }
}
