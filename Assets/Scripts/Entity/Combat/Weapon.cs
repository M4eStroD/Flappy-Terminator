using System;
using System.Collections;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Bullet _bullet;
    [SerializeField] private Transform _container;

    private IBulletFactory _bulletFactory;
    private bool _isReady = true;
    private float _intervalAttack = 1.5f;

    public event Action<Entity> OnHit;

    private void Start()
    {
        _bulletFactory = ServiceLocator.Instance.Resolve<IBulletFactory>();
    }

    public void Initialize(Transform bulletContainer)
    {
        _container = bulletContainer;
    }

    public void Shoot()
    {
        if (_isReady == false)
            return;

        SpawnBullet();
        StartCoroutine(Reload());
    }

    private void SpawnBullet()
    {
        Bullet bullet = _bulletFactory.Create(transform, transform.rotation, _container);

        Subscribe(bullet);
    }

    private void RemoveBullet(Bullet bullet)
    {
        Unsubscribe(bullet);
    }

    private void Subscribe(Bullet bullet)
    {
        bullet.OnCrashed += RemoveBullet;
    }

    private void Unsubscribe(Bullet bullet)
    {
        bullet.OnCrashed -= RemoveBullet;
    }

    private IEnumerator Reload()
    {
        _isReady = false;
        yield return new WaitForSeconds(_intervalAttack);
        _isReady = true;
    }
}
