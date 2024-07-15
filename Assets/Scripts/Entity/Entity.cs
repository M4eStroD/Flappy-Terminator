using UnityEngine;

public abstract class Entity : MonoBehaviour
{
    [SerializeField] protected Weapon _weapon;

    public abstract void Die();
    protected abstract void Attack(Entity target);
}
