public interface IEnemyFactory
{
    EnemyBase Create(EnemyConfig config, ITarget target);
}