using UnityEngine;

public class TowerShooting : TowerComponent
{
    [SerializeField] private Transform _rotatePivotPoint;
    [SerializeField] private Transform _firePoint;
    [SerializeField] private BulletConfig _bulletConfig;
    [SerializeField] private WeaponStrategy _currentStrategy;

    private EnemyBase _currentTrackedEnemy;

    private void Awake() 
    {
        _currentStrategy?.Initialize();
    }

    private void Update() 
    {
        AssignClosestEnemy();
        if(_currentTrackedEnemy) RotateTowardsEnemy();

        //_currentStrategy.Fire(_firePoint, _bulletConfig);
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
}