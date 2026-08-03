using System;
using TMPro;
using UnityEngine;

public class TimerView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _timerText;

    private const string TimeFormat = "{0:00}:{1:00}";

    public void SetTime(float time)
    {
        TimeSpan t = TimeSpan.FromSeconds(time);

        _timerText.SetText(TimeFormat, t.Minutes, t.Seconds);
    }

    public void Clear()
    {
        _timerText.text = "00:00"; 
    }
}