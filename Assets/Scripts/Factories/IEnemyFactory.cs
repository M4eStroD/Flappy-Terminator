using UnityEngine;

public interface IEnemyFactory
{
    Enemy Create(Vector3 position, Quaternion rotate, Transform parent = null);
    void Clear();
}