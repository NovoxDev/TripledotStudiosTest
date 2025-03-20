using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class ButtonHighlighterView : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private Image _highlightImage;

    [Header("Parameters")]
    [SerializeField] private float _highlighterAnimationDuration = .1f;
    [SerializeField] private AnimationCurve _animationCurve;

    public void SetPosition(float xPosition)
    {
        _highlightImage.rectTransform.DOLocalMoveX(xPosition, _highlighterAnimationDuration).SetEase(_animationCurve);
    }

    public void SetWidth(float width)
    {
        _highlightImage.rectTransform.DOSizeDelta(new Vector3(width, _highlightImage.rectTransform.sizeDelta.y), _highlighterAnimationDuration);
    }

    public void Toggle(bool enabled)
    {
        _highlightImage.DOFade(enabled ? 1 : 0, _highlighterAnimationDuration);
    }
}
