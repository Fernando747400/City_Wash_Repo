using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Timer : MonoBehaviour
{
    [Header("Dependecies")]
    [SerializeField] private TextMeshProUGUI _seconds;

    [Header("Settings")]
    [SerializeField] private float _time = 90;

    [Header("Debugging")]
    [SerializeField] private Logger _logger;

    private bool _isPaused = true;


    public float TimerTime { get { return _time; } set { _time = value; } }

    private void Start()
    {
        _seconds.text = Math.Ceiling(_time).ToString();
    }


    void Update()
    {
        ChangeTime();
    }

    private void ChangeTime()
    {
        Log(_time);
        if (_time <= 0)
        {
            _seconds.text = "00";
            _time = 0;
            GameManager.current.EndGame();
            GameManager.current.LostGame();
            return;
        }

        if (!_isPaused)
        {
            float time = (float)Math.Ceiling(_time);
            if (time >= 10) _seconds.text = time.ToString();
            else
            {
                _seconds.text = "0" + time.ToString();
                iTween.PunchScale(_seconds.gameObject, iTween.Hash("amount", new Vector3(0.3f,0.3f,0.3f), "time", 1f));
            }
            _time -= Time.deltaTime;
        }     
    }

    public void PauseTimer() => _isPaused = true;
    public void UnpauseTimer() => _isPaused = false;

    void Log(object message)
    {
        if (_logger)
        {
            _logger.Log(message, this);
        }
    }
}
