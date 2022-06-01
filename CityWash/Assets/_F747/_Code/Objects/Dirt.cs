using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dirt : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private bool _shrinkOnCleaned;

    [Header("Debugging")]
    [SerializeField] private Logger _logger;


    public void CleanDirt()
    {
        Log("I got cleaned! " + this.gameObject.name);
        if (_shrinkOnCleaned) iTween.ScaleTo(this.gameObject, iTween.Hash("scale", Vector3.zero, "time", 3f, "oncomplete", "DestroyObject"));
        else DestroyObject();
    }

    private void DestroyObject()
    {
        GameManager.current.CountPoint();
        Log("Time to get destroyed " + this.gameObject.name);
        Destroy(this.gameObject);
    }

    void Log(object message)
    {
        if (_logger)
        {
            _logger.Log(message, this);
        }
    }
}
