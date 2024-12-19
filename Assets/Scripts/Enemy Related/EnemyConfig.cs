using UnityEngine;
using VInspector;

[CreateAssetMenu(menuName = "Enemies/Enemy Starting Data", fileName = "Enemy Starting Data")]
public class EnemyConfig : ScriptableObject
{
    public PooledType EnemyType;
    public float Speed;
    [MinMaxSlider(0, 100)] public Vector2Int Health;
}