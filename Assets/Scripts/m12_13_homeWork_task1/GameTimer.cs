using UnityEngine;

public class GameTimer : MonoBehaviour
{
    private float _currentTime;
    private float _progress;

    private void Awake()
    {
        Reset();
    }

    public bool IsTimerActive { get; private set; }

    public void UpdateTimer(float timeToLose)
    {
        _currentTime += Time.deltaTime;

        _progress = timeToLose - _currentTime;

        Debug.Log($"Время до проигрыша: {_progress}");

        if (_progress <= 0f) IsTimerActive = false;
    }

    public void Reset()
    {
        IsTimerActive = true;
        ResetTime();
    }

    private void ResetTime()
    {
        _currentTime = 0f;
        _progress = 0f;
    }
}