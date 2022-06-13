using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class Scoring : MonoBehaviour
{
    [Header("Dependecies")]
    [SerializeField] private TextMeshProUGUI _scoreTMP;
    [SerializeField] private TextMeshProUGUI _coinsTMP;

    [Header("Settings")]
    public float _targetScore = 1;
    public int _coinsPerDirt = 1;

    [Header("Debugging")]
    [SerializeField] private Logger _logger;

    public float _currentScore = 0;

    private void Start()
    {
        _targetScore = GameObject.FindGameObjectsWithTag("Dirt").Length;
        _scoreTMP.text = _currentScore.ToString() + " / " + _targetScore.ToString();
        _coinsTMP.text = PlayerPrefs.GetInt("Coins").ToString();
    }

    public void UpdateScore()
    {
        _currentScore++;
        _scoreTMP.text = _currentScore.ToString() + " / " + _targetScore.ToString();
        iTween.PunchScale(_scoreTMP.gameObject, iTween.Hash("amount", new Vector3(0.3f, 0.3f, 0.3f), "time", 0.5f));

        if (_currentScore == _targetScore)
        {
            GameManager.current.EndGame();
            GameManager.current.WinGame();
        }
    }

    public void UpdateCoins()
    {
        PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") + _coinsPerDirt);
        _coinsTMP.text = PlayerPrefs.GetInt("Coins").ToString();
        iTween.PunchScale(_coinsTMP.gameObject, iTween.Hash("amount", new Vector3(0.3f, 0.3f, 0.3f), "time", 0.5f));
    }

    void Log(object message)
    {
        if (_logger)
        {
            _logger.Log(message, this);
        }
    }

}
