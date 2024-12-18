using UnityEngine;

public abstract class WeaponStrategy : ScriptableObject
{
    public float Damage = 1f;
    public float FireCooldown = 1f;
    public float ProjectileSpeed = 10f;
    public float ProjectileLifetime = 5f; 

    protected BulletFactory _bulletFactory;

    public virtual void Initialize()
    {
        _bulletFactory = new BulletFactory();
    }

    public abstract void Fire(Transform firePoint, BulletConfig bulletConfig);
}
