using DG.Tweening;
using UnityEngine;

public class BottomBarView : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private RectTransform _bottomBarRectTrasform;
    [SerializeField] private ButtonHighlighterView _buttonHighlighter;
    [Header("MenuItemViews")]
    [SerializeField] private MenuItemView[] _menuItems;

    [Header("Animation Parameters")]
    [SerializeField] private float _expandedFactor = 1.5f;
    [SerializeField] private float _iconAnimationDuration = .2f;
    [SerializeField] private float _bottomBarToggleAnimationDuration = .2f;

    private float _bottomBarWidth;
    private MenuItemView _currentItemSelected;

    private void Start()
    {
        PositionButtons();
    }

    private void OnEnable()
    {
        AddButtonsListeners();
    }

    private void OnDisable()
    {
        RemoveButtonsListeners();
    }

    private void OnValidate()
    {
        if (_bottomBarRectTrasform == null) return;

        _bottomBarWidth = _bottomBarRectTrasform.rect.width;

        PositionButtons();
    }

    private void PositionButtons()
    {
        _bottomBarWidth = _bottomBarRectTrasform.rect.width;

        var totalItems = _menuItems.Length;
        if (totalItems == 0) return;

        float itemWidth = _bottomBarWidth / totalItems;
        float startX = -_bottomBarWidth / 2;

        foreach (MenuItemView item in _menuItems)
        {
            var itemRect = item.GetComponent<RectTransform>();

            itemRect.sizeDelta = new(itemWidth, itemRect.sizeDelta.y);
            itemRect.anchoredPosition = new Vector2(startX + itemWidth / 2, itemRect.anchoredPosition.y);
            startX += itemWidth;
        }
    }

    private void RepositionButtons(MenuItemView selectedItem)
    {
        var totalItems = _menuItems.Length;
        if (totalItems == 0) return;

        if (selectedItem.IsLocked)
        {
            selectedItem.SelectLocked();
            return;
        }

        MenuItemView lastSelectedItem = null;

        if (selectedItem == _currentItemSelected)
        {
            lastSelectedItem = _currentItemSelected;
            _currentItemSelected = null;
        }
        else
        {
            lastSelectedItem = selectedItem;
            _currentItemSelected = selectedItem;
        }

        var isSelectingItem = _currentItemSelected != null;

        _buttonHighlighter.Toggle(isSelectingItem);

        float expandedWidth = isSelectingItem ? (_bottomBarWidth / totalItems) * _expandedFactor : _bottomBarWidth / totalItems;
        float remainingWidth = _bottomBarWidth - expandedWidth;
        float normalWidth = isSelectingItem ? remainingWidth / (totalItems - 1) : _bottomBarWidth / totalItems;
        float startX = -_bottomBarWidth / 2;

        _buttonHighlighter.SetWidth(expandedWidth);

        float xPosition = 0f;

        foreach (var item in _menuItems)
        {
            var itemRect = item.MenuItemRectTransform;
            float targetWidth = (item == selectedItem) ? expandedWidth : normalWidth;
            itemRect.DOSizeDelta(new(targetWidth, itemRect.sizeDelta.y), 0.2f).SetEase(Ease.OutBack);
            itemRect.DOAnchorPosX(startX + targetWidth / 2, .2f).SetEase(Ease.OutSine);

            if (item == _currentItemSelected)
            {
                item.Select();
                xPosition = startX + targetWidth / 2;
            }
            else
            {
                if (item == lastSelectedItem)
                {
                    xPosition = startX + targetWidth / 2;
                }
                item.Unselect();
            }

            startX += targetWidth;
        }

        _buttonHighlighter.SetPosition(xPosition);
    }

    private void AddButtonsListeners()
    {
        foreach (MenuItemView item in _menuItems)
        {
            item.MenuButton.onClick.AddListener(() => RepositionButtons(item));
        }
    }

    private void RemoveButtonsListeners()
    {
        foreach (MenuItemView item in _menuItems)
        {
            item.MenuButton.onClick.RemoveAllListeners();
        }
    }
}
