using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("References")] 
    [SerializeField] private List<EnemyConfig> _enemyConfigs;
    [SerializeField] private EnemySpawnStrategy spawnStrategy;
    [SerializeField] private Tower _tower;
    [SerializeField] private float _maxEnemies;

    private IEnemyFactory factory = new EnemyFactory();

    private void Start()
    {
        SpawnEnemies();
    }

    private void SpawnEnemies()
    {
        for (int i = 0; i < _maxEnemies; i++)
        {
            EnemyBase enemy = factory.Create(_enemyConfigs[i % _enemyConfigs.Count], _tower);
            enemy.transform.position = spawnStrategy.SetPosition(transform.position);
        }
    }
}