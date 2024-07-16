using UnityEngine;

[RequireComponent(typeof(BirdCollisionHandler))]
public abstract class Entity : MonoBehaviour
{
    private BirdCollisionHandler _handler;

    protected virtual void Awake()
    {
        _handler = GetComponent<BirdCollisionHandler>();
    }

    private void OnEnable()
    {
        _handler.CollisionDetected += ProcessColision;
    }

    private void OnDisable()
    {
        _handler.CollisionDetected -= ProcessColision;
    }

    public abstract void Die();

    protected void ProcessColision()
    {
        Die();
    }
}
