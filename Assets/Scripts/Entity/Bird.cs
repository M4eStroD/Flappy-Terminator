using System;
using UnityEngine;

[RequireComponent(typeof(BirdMover))]
[RequireComponent(typeof(BirdCollisionHandler))]
public class Bird : Entity
{
    private BirdMover _birdMover;
    private BirdCollisionHandler _handler;

    public event Action GameOver;

    private void Awake()
    {
        _birdMover = GetComponent<BirdMover>();
        _handler = GetComponent<BirdCollisionHandler>();
    }

    private void OnEnable()
    {
        _handler.CollisionDetected += ProcessColision;
        _weapon.OnHit += Attack;
    }

    private void OnDisable()
    {
        _handler.CollisionDetected -= ProcessColision;
        _weapon.OnHit -= Attack;
    }

    public override void Die()
    {
        GameOver?.Invoke();
    }

    protected override void Attack(Entity target)
    {
        if (target == null || target == this) return;

        target.Die();
    }

    public void Reset()
    {
        _birdMover.Reset();
    }

    private void ProcessColision(IInteractable interactable)
    {
        GameOver?.Invoke();
    }
}
