using UnityEngine;
using VInspector;

public class TowerShooting : TowerComponent
{
    [SerializeField] private Transform _rotatePivotPoint;
    [SerializeField] private Transform _firePoint;
    [SerializeField] private BulletConfig _bulletConfig;
    [SerializeField] private WeaponStrategy _currentStrategy;

    [SerializeField] [ReadOnly] private WeaponCurrentData _weaponCurrentData;
    private EnemyBase _currentTrackedEnemy;
    private Timer _fireCooldownTimer;

    public WeaponCurrentData GetWeaponCurrentData => _weaponCurrentData;

    private void Awake() 
    {
        SetWeaponStrategy(_currentStrategy);
        _fireCooldownTimer = new Timer(_currentStrategy.FireCooldown);
        _fireCooldownTimer.Start();
    }

    private void Update() 
    {
        AssignClosestEnemy();
        _fireCooldownTimer.Update(Time.deltaTime);

        if(!_currentTrackedEnemy) return;

        RotateTowardsEnemy();

        if(!_fireCooldownTimer.IsRunning)
        {
            if(IsLockedIn())
            {
                _currentStrategy.Fire(_firePoint, _bulletConfig);
                _fireCooldownTimer.Reset(_currentStrategy.FireCooldown, true);
            }
        }
    }

    public void SetWeaponStrategy(WeaponStrategy strategyToSet)
    {
        _currentStrategy = strategyToSet;
        _currentStrategy.Initialize();

        //calcualte current data based on unlocked abilities/powerups etc
        //then use that instead of values from SO

        _weaponCurrentData = new WeaponCurrentData(_currentStrategy);
    }

    private void AssignClosestEnemy()
    {
        var aliveEnemiesList = GameManager.Instance.GetAliveEnemies;

        if (aliveEnemiesList.Count <= 0)
        {
            _currentTrackedEnemy = null;
            return;
        }

        float closestDistance = float.MaxValue;
        EnemyBase closestEnemy = null;

        foreach (var enemy in aliveEnemiesList)
        {
            float distance = Vector2.Distance(transform.position, enemy.transform.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestEnemy = enemy;
            }
        }

        _currentTrackedEnemy = closestEnemy;
    }

    private void RotateTowardsEnemy()
    {
        if (_currentTrackedEnemy == null) return;

        Vector3 direction = -(_currentTrackedEnemy.transform.position - _rotatePivotPoint.position);
        float targetAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        float step = _currentStrategy.RotationSpeed * Time.deltaTime;
        float angle = Mathf.MoveTowardsAngle(_rotatePivotPoint.eulerAngles.z, targetAngle, step);

        _rotatePivotPoint.rotation = Quaternion.Euler(0, 0, angle);
    }

    private bool IsLockedIn()
    {
        if (_currentTrackedEnemy == null) return false;
        
        var directionToEnemy = _currentTrackedEnemy.transform.position - _rotatePivotPoint.transform.position;
        var currentForward = -_rotatePivotPoint.transform.right;

        return Vector2.Dot(directionToEnemy, currentForward) >= 0.9f;
    }
}