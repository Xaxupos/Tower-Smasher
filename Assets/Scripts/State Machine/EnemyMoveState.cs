using UnityEngine;

public class EnemyMoveState : EnemyBaseState
{
    private ITarget _target;
    private Rigidbody2D _rigidbody2D;
    private float _stoppingDistance = 1;
    
    public EnemyMoveState(EnemyBase enemy, StateController controller, ITarget target) : base(enemy, controller)
    {
        _target = target;
    }

    public override void EnterState()
    {
        _rigidbody2D = _enemy.GetComponent<Rigidbody2D>();
    }

    public override void FixedUpdateState()
    {
        return;
        if (_target == null) return;

        Vector2 direction = (_target.gameObject.transform.position - _enemy.transform.position).normalized;
        float distance = Vector2.Distance(_enemy.transform.position, _target.gameObject.transform.position);

        if (distance > _stoppingDistance)
        {
            _rigidbody2D.linearVelocity = direction * _enemy.GetCurrentData().Speed;
        }
        else
        {
            _rigidbody2D.linearVelocity = Vector2.zero;
            _controller.SetNewState(new EnemyAttackState(_enemy, _controller, _target));
        }
    }

    public override void ExitState()
    {
        _rigidbody2D.linearVelocity = Vector2.zero;
    }
}