using UnityEngine;

public class Tower : MonoBehaviour, ITarget
{
    [Header("Dependencies")] 
    [SerializeField] private TowerShooting _towerShooting;
    [SerializeField] private TowerTargeting _towerTargeting;

    private void Start()
    {
        _towerShooting.Initialize(this);
        _towerTargeting.Initialize(this);
    }
}