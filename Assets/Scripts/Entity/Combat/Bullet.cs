using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
    private const float SpeedPhysicsFactor = 20f;

    [SerializeField] private float _speedBullet;

    private Rigidbody2D _rigidBody2D;
    private Vector3 _direction;

    public event Action<Bullet> OnCrashed;

    private void Awake()
    {
        _rigidBody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        MoveTowards();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Entity entity))
            OnCrashed?.Invoke(this);
        else
            OnCrashed?.Invoke(this);
    }

    public void SetDirection(Vector3 direction)
    {
        _direction = direction.normalized;
    }

    private void MoveTowards()
    {
        _rigidBody2D.velocity = _direction * (_speedBullet * SpeedPhysicsFactor * Time.fixedDeltaTime);
    }
}
