using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FinalScore : MonoBehaviour
{
    [Header("Dependecies")]
    [SerializeField] private TextMeshProUGUI _finalScore;
    [SerializeField] private Scoring _scoringScript;
    private void OnEnable()
    {
        _finalScore.text = _scoringScript._currentScore + " / " + _scoringScript._targetScore;
    }
}
