public class EnemyMoveState : IState
{
    private EnemyBase _enemy;
    private ITarget _target;
    
    public EnemyMoveState(EnemyBase enemy, ITarget target)
    {
        _enemy = enemy;
        _target = target;
    }
    
    public void EnterState() { }
    public void UpdateState() { }
    public void ExitState(){ }
    public void OnEnable(){ }
    public void OnDisable(){ }
}