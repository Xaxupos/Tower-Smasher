using UnityEngine;
using VInspector;

public class EnemyBase : MonoBehaviour, ITarget
{
    [SerializeField] private EnemyStateController _stateController;
    [SerializeField] private EnemyConfig config;
    [SerializeField] [ReadOnly] private EnemyCurrentData _currentData;
    
    public void Initialize(ITarget target)
    {
        _currentData = new EnemyCurrentData();
        CalculateCurrentData();
        _stateController.Initialize(this, target);
    }
    
    public virtual void CalculateCurrentData()
    {
        _currentData.Speed = config.Speed;
        _currentData.Health = Random.Range(config.Health.x, config.Health.y);
    }
    
    public EnemyCurrentData GetCurrentData() => _currentData;
    public EnemyConfig GetStartingData() => config;
}