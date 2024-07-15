using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour, IInteractable
{
    private const float SpeedPhysicsFactor = 20f;

    [SerializeField] private float _speedBullet;

    private Rigidbody2D _rigidBody2D;
    private Vector3 _direction;
    private float _totalSpeed;

    public event Action<Bullet, Entity> OnCrashed;

    private void Awake()
    {
        _rigidBody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        MoveTowards();
    }

    public void SetDirection(Vector3 direction, Quaternion rotate)
    {
        _direction = direction.normalized;

        transform.rotation = rotate;
    }

    private void MoveTowards()
    {
        _totalSpeed = _speedBullet * SpeedPhysicsFactor * Time.fixedDeltaTime;
        _rigidBody2D.velocity = _direction * _totalSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Entity entity))
            OnCrashed?.Invoke(this, entity);
        else
            OnCrashed?.Invoke(this, null);
    }
}
