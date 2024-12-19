using System.Collections.Generic;

public class GameManager : MonoBehaviourSingleton<GameManager>
{
    public List<EnemyBase> AliveEnemies {get; private set;} = new List<EnemyBase>();

    public void AddEnemy(EnemyBase enemy)
    {
        if(AliveEnemies.Contains(enemy)) return;

        AliveEnemies.Add(enemy);
    }
    
    public void RemoveEnemy(EnemyBase enemy)
    {
        if(!AliveEnemies.Contains(enemy)) return;

        AliveEnemies.Remove(enemy);
        PoolManager.Instance.ReleaseToPool(enemy.GetEnemyConfig().EnemyType, enemy.gameObject);
    }

    public List<EnemyBase> GetAliveEnemies => AliveEnemies;
}