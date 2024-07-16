using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory : IEnemyFactory
{
    private const string IdEnenmy = "bird";

    private readonly IDataProvider _dataProvider;
    private readonly ObjectPool<Enemy> _objcetPoolEnemy;

    private readonly HashSet<Enemy> _enemies;

    private int _enemyCount = 2;

    public EnemyFactory(IDataProvider dataProvider)
    {
        _dataProvider = dataProvider;
        _objcetPoolEnemy = new ObjectPool<Enemy>();

        _enemies = new HashSet<Enemy>();

        InitialPool(_enemyCount);
    }

    public Enemy Create(Vector3 position, Quaternion rotate, Transform parent = null)
    {
        Enemy tempEnemy = _objcetPoolEnemy.GetObject();

        if (tempEnemy == null)
        {
            tempEnemy = Object.Instantiate(_dataProvider.GetEnemy(IdEnenmy).Prefab);
            _enemies.Add(tempEnemy);
            tempEnemy.GetComponent<EnemyAttack>().Initialize(parent);

            tempEnemy.OnDied += EnemyDie;
        }

        tempEnemy.transform.position = position;
        tempEnemy.transform.rotation = rotate;
        tempEnemy.transform.SetParent(parent);

        tempEnemy.gameObject.SetActive(true);

        return tempEnemy;
    }

    public void Clear()
    {
        foreach (Enemy enemy in _enemies)
        {
            enemy.OnDied -= EnemyDie;
            Object.Destroy(enemy.gameObject);
        }

        _objcetPoolEnemy.Clear();
        _enemies.Clear();
    }

    private void InitialPool(int count)
    {
        for (int i = 0; i < count; i++)
        {
            Enemy tempEnemy = Object.Instantiate(_dataProvider.GetEnemy(IdEnenmy).Prefab);
            _enemies.Add(tempEnemy);

            tempEnemy.OnDied += EnemyDie;
            tempEnemy.GetComponent<EnemyAttack>().Initialize(null);

            _objcetPoolEnemy.PutObject(tempEnemy);
            tempEnemy.gameObject.SetActive(false);
        }
    }

    private void EnemyDie(Enemy enemy)
    {
        enemy.gameObject.SetActive(false);
        _objcetPoolEnemy.PutObject(enemy);
    }
}
