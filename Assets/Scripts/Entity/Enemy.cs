using UnityEngine;

public class Enemy : Entity, IInteractable
{
    public void Initialize(Transform bulletContainer)
    {
        _weapon.Initialize(bulletContainer);
    }

    public override void Die()
    {
        gameObject.SetActive(false);
    }

    protected override void Attack(Entity target)
    {
        if (target == null) return;

        target.Die();
    }
}