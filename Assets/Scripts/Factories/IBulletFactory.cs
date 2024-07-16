using UnityEngine;

public interface IBulletFactory
{
    void Clear();
    Bullet Create(Transform weaponTransform, Quaternion rotate, Transform parent = null);
}