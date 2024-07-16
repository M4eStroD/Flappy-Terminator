using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private const string IdEnenmy = "bird";
    private const float PreparationTime = 1.5f;

    [SerializeField] private float _delay;
    [SerializeField] private float _lowerBound;
    [SerializeField] private float _upperBound;

    [SerializeField] private Transform _enemyContainer;
    [SerializeField] private Transform _bulletContainer;

    private Coroutine _spawnCorutine;

    private IEnemyFactory _enemyFactory;

    public void Initialize()
    {
        _enemyFactory = ServiceLocator.Instance.Resolve<IEnemyFactory>();
        _spawnCorutine = StartCoroutine(GenerateEnemy());
    }

    public void Reset()
    {
        StopCoroutine(_spawnCorutine);
        _enemyFactory.Clear();
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

        Enemy enemy = _enemyFactory.Create(spawnPoint, Quaternion.identity, _enemyContainer);
    }
}
