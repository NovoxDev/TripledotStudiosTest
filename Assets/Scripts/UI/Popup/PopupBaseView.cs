using UnityEngine;

/// <summary>
/// Base Popup View class. Derive from this class to develop custom behaviours.
/// </summary>
public abstract class PopupBaseView : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] protected Animator _popupAnimator;

    [Header("Animator parameters")]
    [SerializeField] private string _openStateName;
    [SerializeField] private string _closeStateName;

    private int _openStateHash;
    private int _closeStateHash;

    private void Awake()
    {
        _openStateHash = Animator.StringToHash(_openStateName);
        _closeStateHash = Animator.StringToHash(_closeStateName);
    }

    public virtual void ToggleView(bool active)
    {
        _popupAnimator.CrossFade(active ? _openStateHash : _closeStateHash, 0, 0);
    }
}
