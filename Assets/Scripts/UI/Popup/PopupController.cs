using UnityEngine;

public class PopupController : MonoBehaviour
{
    [SerializeField] private PopupBackgroundView _popupBackgroundView;
    [SerializeField] private PopupSettingsView _popupSettingsView;

    public void TogglePopupSettingsView(bool active)
    {
        _popupBackgroundView.ToggleView(active);
        _popupSettingsView.ToggleView(active);
    }

    private void ToggleBackgroundView(bool active)
    {
        _popupBackgroundView.ToggleView(active);
    }
}
