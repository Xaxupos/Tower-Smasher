using System.Collections.Generic;

public class GameManager : MonoBehaviourSingleton<GameManager>
{
    public List<EnemyBase> AliveEnemies {get; private set;} = new List<EnemyBase>();

    public void AddEnemy(EnemyBase enemy) => AliveEnemies.Add(enemy);
    public void RemoveEnemy(EnemyBase enemy) => AliveEnemies.Remove(enemy);

    public List<EnemyBase> GetAliveEnemies => AliveEnemies;
}