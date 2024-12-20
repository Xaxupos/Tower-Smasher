using UnityEngine;

public class ChainingBulletImpactFeature : BulletImpactFeature
{
    private int _maxChains;
    private float _chainRange;
    private int _currentChains;
    private EnemyBase _lastHitEnemy;
    private BulletFactory _bulletFactory;
    private WeaponStrategy _weaponStrategy;

    public ChainingBulletImpactFeature(int maxChains, float chainRange, BulletFactory bulletFactory, WeaponStrategy weaponStrategy)
    {
        _maxChains = maxChains;
        _chainRange = chainRange;
        _currentChains = 0;
        _bulletFactory = bulletFactory;
        _weaponStrategy = weaponStrategy;
    }

    public override void OnImpact(BulletBase bullet, Collision2D collision)
    {
        if (_currentChains >= _maxChains) return;

        _lastHitEnemy = collision.gameObject.GetComponent<EnemyBase>();
        if (_lastHitEnemy == null) return;

        _currentChains++;
        EnemyBase nextTarget = FindNextTarget(_lastHitEnemy.transform.position);
        if (nextTarget != null)
        {
            Vector3 direction = (nextTarget.transform.position - _lastHitEnemy.transform.position).normalized;
            BulletBase newBullet = _bulletFactory.Create(bullet.BulletConfig, _weaponStrategy, _lastHitEnemy.transform);
            newBullet.transform.right = direction;
            var newChainingFeature = new ChainingBulletImpactFeature(_maxChains, _chainRange, _bulletFactory, _weaponStrategy)
            {
                _currentChains = _currentChains,
                _lastHitEnemy = _lastHitEnemy
            };
            newBullet.AddImpactFeature(newChainingFeature);
        }
    }

    private EnemyBase FindNextTarget(Vector3 position)
    {
        var aliveEnemiesList = GameManager.Instance.GetAliveEnemies;
        EnemyBase closestEnemy = null;
        float closestDistance = float.MaxValue;

        foreach (var enemy in aliveEnemiesList)
        {
            if (enemy == _lastHitEnemy) continue;

            float distance = Vector2.Distance(position, enemy.transform.position);
            if (distance < closestDistance && distance <= _chainRange)
            {
                closestDistance = distance;
                closestEnemy = enemy;
            }
        }

        return closestEnemy;
    }
}