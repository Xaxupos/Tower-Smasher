using UnityEngine;

[CreateAssetMenu(menuName = "Enemy Spawn Strategies/Default Spawn Strategy", fileName = "Default Spawn Strategy")]
public class EnemySpawnStrategy : ScriptableObject
{
    public virtual Vector2 SetPosition(Vector2 origin) => origin;
}