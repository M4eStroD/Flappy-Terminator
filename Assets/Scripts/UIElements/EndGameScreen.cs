using System;

public class EndGameScreen : Window
{
    public event Action RestartButtonClicked;

    private void OnEnable()
    {
        ActionButton.onClick.AddListener(OnButtonClick);
    }

    private void OnDisable()
    {
        ActionButton.onClick.RemoveListener(OnButtonClick);
    }

    public override void Close()
    {
        WindowGroup.alpha = 0;
        ActionButton.interactable = false;
    }

    public override void Open()
    {
        WindowGroup.alpha = 1;
        ActionButton.interactable = true;
    }

    private void OnButtonClick()
    {
        RestartButtonClicked?.Invoke();
    }
}
