using UnityEngine;

[CreateAssetMenu(menuName = "Weapon Strategies/Single Shot Strategy", fileName = "Single Shot Strategy")]
public class SingleShotStrategy : WeaponStrategy
{
    public override void Fire(Transform firePoint, BulletConfig bulletConfig)
    {
        var bullet = _bulletFactory.Create(bulletConfig, this, firePoint);
    }
}