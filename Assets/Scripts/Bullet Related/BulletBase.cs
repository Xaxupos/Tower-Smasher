using UnityEngine;
using UnityEngine.Serialization;
using VInspector;

public class BulletBase : MonoBehaviour
{
    [SerializeField] private BulletConfig config;
    [ReadOnly] [SerializeField] private BulletCurrentData _currentData;

    public void Initialize()
    {
        _currentData = new BulletCurrentData();
        CalculateCurrentData();
    }
    
    public virtual void CalculateCurrentData()
    {
        _currentData.Speed = config.Speed;
        _currentData.OnHitDamage = config.OnHitDamage;
    }
}