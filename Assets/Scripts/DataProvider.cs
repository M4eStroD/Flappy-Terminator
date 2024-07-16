using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DataProvider : IDataProvider
{
    private Dictionary<string, EnemyData> _enemiesData;

    public BulletData BulletData { get; private set; }

    public void Load()
    {
        _enemiesData = Resources.LoadAll<EnemyData>(AssetsPath.EnemyPath).ToDictionary(x => x.ID, x => x);
        BulletData = Resources.Load<BulletData>(AssetsPath.BulletPath);
    }

    public EnemyData GetEnemy(string id)
    {
        if (_enemiesData.ContainsKey(id) == false)
            throw new KeyNotFoundException($"Enemy with ID '{id}' not found.");

        return _enemiesData[id];
    }
}
