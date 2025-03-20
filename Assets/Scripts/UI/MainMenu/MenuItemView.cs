using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class MenuItemView : MonoBehaviour
{
    public RectTransform MenuItemRectTransform => _menuItemRectTransform;
    public Button MenuButton => _menuButton;
    public bool IsLocked => _isLocked;
    public bool IsActivated => _isActivated;

    [Header("Components")]
    [SerializeField] private RectTransform _menuItemRectTransform;
    [SerializeField] private Button _menuButton;
    [SerializeField] private Image _menuButtonImage;
    [SerializeField] private TextMeshProUGUI _menuButtonText;

    [Header("Content parameters")]
    [SerializeField] private int _contentId;

    [Header("Events")]
    public UnityEvent<int> OnContentActivated;
    public UnityEvent<int> OnContentDeactivated;

    [Header("Animation parameters")]

    [Header("Icon animation parameters")]
    [SerializeField] private float _imageMovementDelta = .2f;
    [SerializeField] private float _imageScaleFactor = 1.1f;
    [SerializeField] private float _animationDuration =.2f;
    [SerializeField] private AnimationCurve _imageScaleCurve;
    [SerializeField] private AnimationCurve _imagePositionCurve;

    [SerializeField] private float _lockedAnimationDuration = .2f;
    [SerializeField] private float _lockedAnimationStrength = 10.0f;
    [SerializeField] private int _lockedAnimationVibrato = 30;

    [Header("Mock parameters")]
    [SerializeField] private bool _isLocked = false;

    private Vector3 _startImagePosition;
    private Vector3 _startImageScale;
    private bool _isActivated = false;

    private void Awake()
    {
        _startImagePosition = _menuButtonImage.rectTransform.localPosition;
        _startImageScale = _menuButtonImage.rectTransform.localScale;

        _menuButtonText.gameObject.SetActive(false);
    }

    public void Select()
    {
        _menuButtonText.gameObject.SetActive(true);

        _menuButtonImage.rectTransform.DOScale(_startImageScale * _imageScaleFactor, _animationDuration).SetEase(_imageScaleCurve);
        _menuButtonImage.rectTransform.DOLocalMoveY(
            _startImagePosition.y + _imageMovementDelta, _animationDuration).SetEase(_imagePositionCurve);
        _menuButtonText.DOFade(1, _animationDuration);

        _isActivated = true;

        OnContentActivated?.Invoke(_contentId);
    }

    public void Unselect()
    {
        _menuButtonImage.rectTransform.DOLocalMoveY(_startImagePosition.y, _animationDuration).SetEase(Ease.Unset);
        _menuButtonImage.rectTransform.DOScale(_startImageScale, _animationDuration).SetEase(Ease.Unset);
        _menuButtonText.DOFade(0, _animationDuration).OnComplete(() => _menuButtonText.gameObject.SetActive(true));

        _isActivated = false;

        OnContentDeactivated?.Invoke(_contentId);
    }

    public void SelectLocked()
    {
        _menuButtonImage.rectTransform.DOShakePosition(_lockedAnimationDuration, _lockedAnimationStrength, _lockedAnimationVibrato);
    }
}