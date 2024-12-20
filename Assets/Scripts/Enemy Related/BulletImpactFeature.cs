using UnityEngine;

public abstract class BulletImpactFeature
{
    public abstract void OnImpact(BulletBase bullet, Collision2D collision);
}