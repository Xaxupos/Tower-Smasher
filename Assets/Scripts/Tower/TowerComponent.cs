using UnityEngine;

public abstract class TowerComponent : MonoBehaviour
{
    protected TowerBase _towerBase;
    
    public virtual void Initialize(TowerBase towerBase)
    {
        _towerBase = towerBase;
    }

    protected virtual void LoadStartingData() {}
}