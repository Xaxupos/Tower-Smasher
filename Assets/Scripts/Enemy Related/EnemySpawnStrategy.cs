using UnityEngine;
using VInspector;

[CreateAssetMenu(menuName = "Enemy Spawn Strategies/Default Spawn Strategy", fileName = "Default Spawn Strategy")]
public class EnemySpawnStrategy : ScriptableObject
{
    [MinMaxSlider(0.1f, 5)] public Vector2 SpawnInterval = new Vector2(1f, 3f);
    public virtual Vector2 SetPosition(Vector2 origin) => origin;
}