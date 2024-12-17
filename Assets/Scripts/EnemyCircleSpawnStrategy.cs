using UnityEngine;

[CreateAssetMenu(menuName = "Enemy Spawn Strategies/Circular Spawn Strategy", fileName = "Circular Spawn Strategy")]
public class EnemyCircleSpawnStrategy : EnemySpawnStrategy
{
    public float MinDistance;
    public float MaxDistance = 10;

    public override Vector2 SetPosition(Vector2 origin)
    {
        return origin.RandomPointInAnnulus(MinDistance, MaxDistance);
    }
}