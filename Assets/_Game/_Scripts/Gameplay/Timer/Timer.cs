using System;

public class Timer
{
    private float _duration;
    private float _time;

    public bool IsRunning { get; private set; }
    public bool IsFinished => !IsRunning && _time <= 0;

    public event Action Completed;

    public Timer(float duration)
    {
        _duration = duration;
    }

    public void Start()
    {
        _time = _duration;
        IsRunning = true;
    }

    public void Stop()
    {
        IsRunning = false;
    }

    public void Reset()
    {
        _time = _duration;
    }

    public void Tick(float deltaTime)
    {
        if (!IsRunning)
            return;

        _time -= deltaTime;

        if (_time <= 0)
        {
            _time = 0;
            IsRunning = false;
            Completed?.Invoke();
        }
    }

    public float RemainingTime => _time;
    public float Progress => 1f - (_time / _duration);
}