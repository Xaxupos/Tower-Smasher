using UnityEngine;

[CreateAssetMenu(menuName = "Bullets/Bullet Starting Data", fileName = "Bullet Starting Data")]
public class BulletConfig : ScriptableObject
{
    public PooledType BulletType;
    public float Speed;
    public float OnHitDamage;
}