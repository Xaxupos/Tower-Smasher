using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("References")] 
    [SerializeField] private List<EnemyConfig> _enemyConfigs;
    [SerializeField] private EnemySpawnStrategy _spawnStrategy;
    [SerializeField] private Tower _tower;
    [SerializeField] private float _maxEnemies;

    private IEnemyFactory factory = new EnemyFactory();

    private void Start()
    {
        if(_maxEnemies > 0)
            SpawnEnemies();
        else
            StartCoroutine(InfiniteEnemiesSpawner());
    }

    private void SpawnEnemies()
    {
        for (int i = 0; i < _maxEnemies; i++)
        {
            CreateAndSetRandomEnemy();
        }
    }

    private void CreateAndSetRandomEnemy()
    {
        var randomEnemyIndex = Random.Range(0, _enemyConfigs.Count);
        EnemyBase enemy = factory.Create(_enemyConfigs[randomEnemyIndex], _tower);
        enemy.transform.position = _spawnStrategy.SetPosition(transform.position);
    }

    private IEnumerator InfiniteEnemiesSpawner()
    {
        while(true)
        {
            CreateAndSetRandomEnemy();
            yield return new WaitForSeconds(Random.Range(_spawnStrategy.SpawnInterval.x, _spawnStrategy.SpawnInterval.y));
        }
    }
}