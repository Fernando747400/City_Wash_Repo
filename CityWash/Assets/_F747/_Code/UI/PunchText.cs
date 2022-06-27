using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchText : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private Vector3 _punchScale;
    [SerializeField] private float _time;

    void Start()
    {
        iTween.PunchScale(this.gameObject, iTween.Hash("amount", _punchScale, "time", _time, "looptype", "loop", "ignoretimescale", true));
    }

}
