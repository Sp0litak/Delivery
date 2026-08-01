using System;
using TMPro;
using UnityEngine;

public class TimerView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _timerText;

    public void SetTime(float time)
    {
        TimeSpan t = TimeSpan.FromSeconds(time);
        _timerText.text = $"{t.Minutes:00}:{t.Seconds:00}";
    }

    public void Clear()
    {
        _timerText.text = "00:00";
    }
}