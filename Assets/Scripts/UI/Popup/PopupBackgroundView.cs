using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PopupBackgroundView : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private Image _popupBackgroundImage;

    [Header("Fade parameters")]
    [SerializeField] private float _fadeDuration = .2f;
    [Range(0, 1)]
    [SerializeField] private float _alphaValue = .5f;

    public void ToggleView(bool active)
    {
        if (active)
        {
            ToggleBackgroundImage(true);

            FadeTo(_alphaValue, _fadeDuration);
        }
        else
        {
            FadeTo(0, _fadeDuration, () => ToggleBackgroundImage(false));
        }
    }

    private void ToggleBackgroundImage(bool active)
    {
        _popupBackgroundImage.enabled = active;
    }

    private void FadeTo(float alpha, float duration, UnityAction onComplete = null)
    {
        _popupBackgroundImage.DOFade(alpha, duration).OnComplete(() => onComplete?.Invoke());
    }
}
