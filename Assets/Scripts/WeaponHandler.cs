using UnityEngine;

public class WeaponHandler : MonoBehaviour
{
    [SerializeField] private Weapon _weapon; 

    private IInputService _inputService;

    private void Start()
    {
        _inputService = ServiceLocator.Instance.Resolve<IInputService>();
        _inputService.AttackButtonClick += OnAttackButtonClick;
    }

    private void OnDisable()
    {
        _inputService.AttackButtonClick -= OnAttackButtonClick;
    }

    private void OnAttackButtonClick()
    {
        _weapon.Shoot();
    }
}
