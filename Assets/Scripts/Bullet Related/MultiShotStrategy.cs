using UnityEngine;

[CreateAssetMenu(menuName = "Weapon Strategies/Multi Shot Strategy", fileName = "Multi Shot Strategy")]
public class MultiShotStrategy : WeaponStrategy
{
    [Range(2, 12)] public int BulletCount = 3;

    public override void Fire(Transform firePoint, BulletConfig bulletConfig)
    {
        float angleStep = 30f;
        float startAngle = -angleStep * (BulletCount - 1) / 2;

        for (int i = 0; i < BulletCount; i++)
        {
            float angle = startAngle + i * angleStep;
            Quaternion rotation = Quaternion.Euler(new Vector3(0, 0, angle));
            var bullet = _bulletFactory.Create(bulletConfig, this, firePoint);
            bullet.transform.rotation = firePoint.rotation * rotation;

            Vector3 direction = Quaternion.Euler(0, 0, angle) * -firePoint.right;
            bullet.transform.right = direction;
        }
    }
}