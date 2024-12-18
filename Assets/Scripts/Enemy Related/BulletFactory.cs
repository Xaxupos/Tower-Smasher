using UnityEngine;

public class BulletFactory : IBulletFactory
{
    public BulletBase Create(BulletConfig config, WeaponStrategy weaponStrategy, Transform firePoint)
    {
        GameObject bullet = PoolManager.Instance.GetFromPool(config.BulletType);
        BulletBase bulletComponent = bullet.GetComponent<BulletBase>();
        bullet.transform.position = firePoint.position;
        bullet.transform.right = -firePoint.right;
        bulletComponent.Initialize(weaponStrategy);

        return bulletComponent;
    }
}