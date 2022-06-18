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
        CreatePlayerPrefs();
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void LoadScene(int SceneIndex)
    {
        SceneManager.LoadScene(SceneIndex);
    }

    private void CreatePlayerPrefs()
    {
        if (!PlayerPrefs.HasKey("Coins")){
            PlayerPrefs.SetInt("Coins",0);
        }

        if (!PlayerPrefs.HasKey("Player_speed"))
        {
            PlayerPrefs.SetFloat("Player_speed", 1);
        }

        if (!PlayerPrefs.HasKey("Player_scale"))
        {
            PlayerPrefs.SetFloat("Player_scale", 1);
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
