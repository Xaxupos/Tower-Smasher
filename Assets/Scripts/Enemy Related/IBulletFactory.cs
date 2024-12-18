using UnityEngine;

public interface IBulletFactory
{
    BulletBase Create(BulletConfig config, WeaponStrategy weaponStrategy, Transform firePoint);
}