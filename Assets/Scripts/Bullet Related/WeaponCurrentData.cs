[System.Serializable]

public struct WeaponCurrentData
{
    public float RotationSpeed;
    public float Damage;
    public float FireCooldown;
    public float ProjectileSpeed;
    public float MaxShootingDistance;

    public WeaponCurrentData(WeaponStrategy weaponStrategy)
    {
        RotationSpeed = weaponStrategy.RotationSpeed;
        Damage = weaponStrategy.Damage;
        FireCooldown = weaponStrategy.FireCooldown;
        ProjectileSpeed = weaponStrategy.ProjectileSpeed;
        MaxShootingDistance = weaponStrategy.MaxShootingDistance;
    }
}