using UnityEngine;

public class TowerShooting : TowerComponent
{
    [Header("Shooting Settings")] 
    [SerializeField] private PooledType _currentBulletType;
    [SerializeField] private float _fireCooldown = 2;
}