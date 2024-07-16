using System;
using UnityEngine;

[RequireComponent(typeof(BirdMover))]
public class Bird : Entity
{
    [SerializeField] private Transform _containerBullet;

    private BirdMover _birdMover;

    public event Action GameOver;

    protected override void Awake()
    {
        base.Awake();
        _birdMover = GetComponent<BirdMover>();
    }

    public override void Die()
    {
        GameOver?.Invoke();
    }

    public void Reset()
    {
        _birdMover.Reset();
    }
}
