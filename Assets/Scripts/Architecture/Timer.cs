using System;

public class Timer
{
    private float _timeLeft;
    private bool _isRunning;
    private Action _onFinished;
    private Action _onStarted;

    public Timer(float time, Action onFinished = null, Action onStarted = null)
    {
        _timeLeft = time;
        _isRunning = false;
        _onFinished = onFinished;
        _onStarted = onStarted;
    }

    public void Start()
    {
        if (_isRunning) return;
        
        _isRunning = true;
        _onStarted?.Invoke();
    }

    public void Update(float deltaTime)
    {
        if (!_isRunning) return;

        _timeLeft -= deltaTime;

        if (_timeLeft <= 0)
        {
            _isRunning = false;
            _onFinished?.Invoke();
        }
    }
    
    public void Reset(float newTime, bool alsoStart = false)
    {
        _timeLeft = newTime;
        _isRunning = false;

        if(alsoStart) Start();
    }

    public void StopTimer()
    {
        _isRunning = false;
    }

    public bool IsRunning => _isRunning;
}
