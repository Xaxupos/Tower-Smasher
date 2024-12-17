using UnityEngine;

public abstract class TowerComponent : MonoBehaviour
{
    protected Tower Tower;
    
    public virtual void Initialize(Tower tower)
    {
        Tower = tower;
    }

    protected virtual void LoadStartingData() {}
}