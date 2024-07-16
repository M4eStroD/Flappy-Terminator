public interface IDataProvider
{
    BulletData BulletData { get; }
    EnemyData GetEnemy(string id);
    void Load();
}