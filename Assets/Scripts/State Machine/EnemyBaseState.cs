public class EnemyBaseState : IState
{
    protected EnemyBase _enemy;
    protected StateController _controller;
    
    public EnemyBaseState(EnemyBase enemy, StateController controller)
    {
        _enemy = enemy;
        _controller = controller;
    }
    
    public virtual void EnterState()
    {
        
    }

    public virtual void UpdateState()
    {
        
    }

    public virtual void FixedUpdateState()
    {
        
    }

    public virtual void ExitState()
    {
        
    }

    public virtual void OnEnable()
    {
        
    }

    public virtual void OnDisable()
    {
        
    }
}
