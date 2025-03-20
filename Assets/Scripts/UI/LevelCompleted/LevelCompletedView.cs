using UnityEngine;

public class LevelCompletedView : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private Animator _levelCompleteAnimator;

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
        _levelCompleteAnimator.CrossFade(active ? _openStateHash : _closeStateHash, 0, 0);
    }
}
