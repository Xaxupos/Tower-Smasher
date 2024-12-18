using UnityEngine;

[CreateAssetMenu(menuName = "Bullets/Bullet Starting Data", fileName = "Bullet Starting Data")]
public class BulletConfig : ScriptableObject
{
    public PooledType BulletType;
    public AudioClip FireClip;
    public PooledType FireVFX;
    public AudioClip ImpactClip;
    public PooledType ImpactVFX;
    public float SpeedModificator = 1;
    public float DamageModificator = 1;
    public float ProjectileLifetime = 5;
}