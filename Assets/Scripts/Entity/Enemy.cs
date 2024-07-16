using System;

public class Enemy : Entity
{
    public event Action<Enemy> OnDied;

    public override void Die()
    {
        OnDied?.Invoke(this);
    }
}