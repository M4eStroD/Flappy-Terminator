using System;
using UnityEngine;

[RequireComponent(typeof(Shooting))]
public class Weapon : MonoBehaviour
{
    [SerializeField] private Bullet _bullet;
    [SerializeField] private Transform _container;
    
    private Shooting _shooting; 

    public event Action<Entity> OnHit;

    private void Awake()
    {
        _shooting = GetComponent<Shooting>();
    }

    private void OnEnable()
    {
        _shooting.Fire += SpawnBullet;
    }

    private void OnDisable()
    {
        _shooting.Fire -= SpawnBullet;
    }

    public void Initialize(Transform bulletContainer)
    {
        _container = bulletContainer;
    }

    private void SpawnBullet()
    {
        Bullet bullet = Instantiate(_bullet, transform.position, Quaternion.identity, _container);
        bullet.SetDirection(transform.right, transform.rotation);

        Subscribe(bullet);
    }

    private void RemoveBullet(Bullet bullet, Entity entity)
    {
        OnHit?.Invoke(entity);

        Unsubscribe(bullet);
        Destroy(bullet.gameObject);
    }

    private void Subscribe(Bullet bullet)
    {
        bullet.OnCrashed += RemoveBullet;
    }

    private void Unsubscribe(Bullet bullet)
    {
        bullet.OnCrashed -= RemoveBullet;  
    }
}
