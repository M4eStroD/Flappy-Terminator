using UnityEngine;
using UnityEngine.UI;

public abstract class Window : MonoBehaviour
{
    [SerializeField] private CanvasGroup _windowGroup;
    [SerializeField] private Button _actionButton;

    protected CanvasGroup WindowGroup => _windowGroup;
    protected Button ActionButton => _actionButton;

    public abstract void Open();
    public abstract void Close();
}
