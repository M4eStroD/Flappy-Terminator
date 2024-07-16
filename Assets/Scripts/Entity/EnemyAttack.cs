using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private Weapon _weapon;

    public void Initialize(Transform bulletContainer)
    {
        _weapon.Initialize(bulletContainer);
    }

    private void Update()
    {
        _weapon.Shoot();
    }
}
