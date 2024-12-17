using UnityEngine;

public class EnemyAttackState : EnemyBaseState
{
    private ITarget _target;
    
    public EnemyAttackState(EnemyBase enemy, StateController controller, ITarget target) : base(enemy, controller)
    {
        _target = target;
    }

    public override void EnterState()
    {
        Debug.Log("Entered attack state!");
    }
}