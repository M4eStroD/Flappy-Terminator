using System;
using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private const float PreparationTime = 1.5f;

    [SerializeField] private float _delay;
    [SerializeField] private float _lowerBound;
    [SerializeField] private float _upperBound;

    [SerializeField] private ObjectPool _pool;
    [SerializeField] private Transform _bulletContainer;

    private Coroutine _spawnCorutine;

    public void Initialize()
    {
        _spawnCorutine = StartCoroutine(GenerateEnemy());
    }

    public void Reset()
    {
        StopCoroutine(_spawnCorutine);
    }

    private IEnumerator GenerateEnemy()
    {
        WaitForSeconds wait = new WaitForSeconds(_delay);

        yield return new WaitForSeconds(PreparationTime);

        while (enabled)
        {
            Spawn();
            yield return wait;
        }
    }

    private void Spawn()
    {
        float spawnPositionY = UnityEngine.Random.Range(_upperBound, _lowerBound);
        Vector3 spawnPoint = new Vector3(transform.position.x, spawnPositionY, 0);

        Enemy enemy = _pool.GetObject();
        enemy.Initialize(_bulletContainer);

        enemy.gameObject.SetActive(true);
        enemy.transform.position = spawnPoint;
    }
}
