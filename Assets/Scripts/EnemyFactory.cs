using UnityEngine;

public class EnemyFactory : IEnemyFactory
{
    public EnemyBase Create(EnemyConfig config, ITarget target)
    {
        GameObject enemy = PoolManager.Instance.GetFromPool(config.EnemyType);
        EnemyBase enemyComponent = enemy.GetComponent<EnemyBase>();
        enemyComponent.Initialize(target);
            
        return enemyComponent;
    }
}