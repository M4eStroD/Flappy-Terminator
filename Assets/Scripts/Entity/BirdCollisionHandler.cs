using System;
using UnityEngine;

public class BirdCollisionHandler : MonoBehaviour
{
    public event Action CollisionDetected;

    private void OnValidate()
    {
        GetComponent<Collider2D>().isTrigger = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        CollisionDetected?.Invoke();
    }
}
