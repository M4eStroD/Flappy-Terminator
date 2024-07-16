using System.Collections.Generic;
using UnityEngine;

public class BulletFactory : IBulletFactory
{
    private const string IdBullet = "bullet";

    private readonly IDataProvider _dataProvider;
    private readonly ObjectPool<Bullet> _objcetPoolBullet;

    private readonly HashSet<Bullet> _bullets;

    private int _bulletCount = 5;

    public BulletFactory(IDataProvider dataProvider)
    {
        _dataProvider = dataProvider;
        _objcetPoolBullet = new ObjectPool<Bullet>();

        _bullets = new HashSet<Bullet>();

        InitialPool(_bulletCount);
    }

    public Bullet Create(Transform weaponTransform, Quaternion rotate, Transform parent = null)
    {
        Bullet tempBullet = _objcetPoolBullet.GetObject();

        if (tempBullet == null)
        {
            tempBullet = Object.Instantiate(_dataProvider.BulletData.Prefab);
            _bullets.Add(tempBullet);
            tempBullet.OnCrashed += BulletRemove;
        }

        tempBullet.transform.position = weaponTransform.position;
        tempBullet.transform.rotation = rotate;
        tempBullet.transform.SetParent(parent);
        tempBullet.SetDirection(weaponTransform.right);

        tempBullet.gameObject.SetActive(true);

        return tempBullet;
    }

    public void Clear()
    {
        foreach (Bullet bullet in _bullets)
        {
            bullet.OnCrashed -= BulletRemove;
            Object.Destroy(bullet.gameObject);
        }

        _objcetPoolBullet.Clear();
        _bullets.Clear();
    }

    private void InitialPool(int count)
    {
        for (int i = 0; i < count; i++)
        {
            Bullet tempBullet = Object.Instantiate(_dataProvider.BulletData.Prefab);
            _bullets.Add(tempBullet);

            tempBullet.OnCrashed += BulletRemove;

            _objcetPoolBullet.PutObject(tempBullet);
            tempBullet.gameObject.SetActive(false);
        }
    }

    private void BulletRemove(Bullet bullet)
    {
        bullet.gameObject.SetActive(false);
        _objcetPoolBullet.PutObject(bullet);
    }
}
