using UnityEngine;

public abstract class StateController : MonoBehaviour
{
    protected IState _currentState;

    public virtual void SetNewState(IState newState)
    {
        _currentState?.ExitState();
        _currentState = newState;
        _currentState?.EnterState();
    }

    public virtual void OnEnable()
    {
        _currentState?.OnEnable();
    }
    
    public virtual void Update()
    {
        _currentState?.UpdateState();
    }

    public virtual void FixedUpdate()
    {
        _currentState?.FixedUpdateState();
    }
    
    public virtual void OnDisable()
    {
        _currentState?.OnDisable();
    }
}