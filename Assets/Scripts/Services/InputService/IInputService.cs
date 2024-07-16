using System;

public interface IInputService
{
    event Action AttackButtonClick;
    event Action JumpButtonClick;

    void Disable();
    void Enable();
}