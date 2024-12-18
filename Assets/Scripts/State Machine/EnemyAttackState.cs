using UnityEngine;

public class EnemyAttackState : EnemyBaseState
{
    private ITarget _target;
    private Rigidbody2D _rigidbody2D;
    private float _stoppingDistance = 1;

    public EnemyAttackState(EnemyBase enemy, StateController controller, ITarget target) : base(enemy, controller)
    {
        _target = target;
    }

    public override void EnterState()
    {
        _rigidbody2D = _enemy.GetComponent<Rigidbody2D>();
        Debug.Log("Entered attack state!");
    }


    public override void FixedUpdateState()
    {
        if (_target == null) return;

        float distance = Vector2.Distance(_enemy.transform.position, _target.gameObject.transform.position);

        if(distance > _stoppingDistance)
        {
            _controller.SetNewState(new EnemyMoveState(_enemy, _controller, _target));
        }
    }
}