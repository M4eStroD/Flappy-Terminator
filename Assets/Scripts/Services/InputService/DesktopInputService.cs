using System;
using UnityEngine.InputSystem;

public class DesktopInputService : IInputService
{
    private readonly DesktopInput _desctopInput;

    public event Action AttackButtonClick;
    public event Action JumpButtonClick;

    public DesktopInputService()
    {
        _desctopInput = new DesktopInput();
        Enable();

        _desctopInput.Gameplay.Attack.performed += OnAttackButtonClick;
        _desctopInput.Gameplay.Jump.performed += OnJumpButtonClick;
    }

    public void Enable()
    {
        _desctopInput.Gameplay.Enable();
    }

    public void Disable()
    {
        _desctopInput.Gameplay.Disable();

        _desctopInput.Gameplay.Attack.performed -= OnAttackButtonClick;
        _desctopInput.Gameplay.Jump.performed -= OnJumpButtonClick;
    }

    private void OnAttackButtonClick(InputAction.CallbackContext context)
    {
        AttackButtonClick?.Invoke();
    }

    private void OnJumpButtonClick(InputAction.CallbackContext context)
    {
        JumpButtonClick?.Invoke();
    }
}
