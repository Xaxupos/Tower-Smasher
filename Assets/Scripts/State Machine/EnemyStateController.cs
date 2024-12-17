public class EnemyStateController : StateController
{
    private EnemyBase _enemy;
    private ITarget _target;
    
    public void Initialize(EnemyBase enemy, ITarget target)
    {
        _enemy = enemy;
        _target = target;
        
        SetNewState(new EnemyMoveState(_enemy,this, target));
    }
}