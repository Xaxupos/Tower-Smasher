using UnityEngine;
using VInspector;

public class EnemyBase : MonoBehaviour, ITarget
{
    [SerializeField] private EnemyStateController _stateController;
    [SerializeField] private EnemyConfig _config;
    [SerializeField] private HealthSystem _healthSystem;
    [SerializeField] [ReadOnly] private EnemyCurrentData _currentData;

    public void Initialize(ITarget target)
    {
        _currentData = new EnemyCurrentData();
        CalculateCurrentData();
        _stateController.Initialize(this, target);
        _healthSystem.Initialize(Mathf.RoundToInt(_currentData.Health));
    }
    
    public virtual void CalculateCurrentData()
    {
        _currentData.Speed = _config.Speed;
        _currentData.Health = Random.Range(_config.Health.x, _config.Health.y);
    }
    
    public EnemyCurrentData GetCurrentData() => _currentData;
    public EnemyConfig GetEnemyConfig() => _config;
}