using UnityEngine;
using UnityEngine.Events;

public abstract class EventListener<T> : MonoBehaviour
{
    [SerializeField] private EventChannel<T> _eventChannel;
    [SerializeField] private UnityEvent<T> _unityEvent;

    protected void Awake()
    {
        _eventChannel.Register(this);
    }

    protected void OnDestroy()
    {
        _eventChannel.Deregister(this);
    }

    public void Raise(T value)
    {
        _unityEvent?.Invoke(value);
    }
}