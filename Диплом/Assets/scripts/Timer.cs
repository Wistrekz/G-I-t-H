using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Timer : MonoBehaviour
{
    [SerializeField] private float time;
    private float _timeLeft = 0f;
    public IEnumerator StartTimer()
    {
        while (_timeLeft > 0)
        {
            _timeLeft -= Time.deltaTime;
            UpdateTimeText();
            yield return null;
        }
    }

    public void StartTime()
    {
        _timeLeft = time;
        StartCoroutine(StartTimer());
    }

    public void UpdateTimeText()
    {
        if (_timeLeft < 0)
            _timeLeft = 0;

        Mathf.FloorToInt(_timeLeft / 60);
        Mathf.FloorToInt(_timeLeft % 60);
        Debug.Log("end");
    }
}
