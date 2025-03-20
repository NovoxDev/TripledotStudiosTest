using System;
using UnityEngine;
using UnityEngine.UI;

public class ToggleView : MonoBehaviour
{
    [SerializeField] private Toggle _toggleComponent;

    [SerializeField] private Image _toggleSprite;
    [SerializeField] private Sprite _toggledSprite;
    [SerializeField] private Sprite _untoggledSprite;

    private void Start()
    {
        _toggleComponent.onValueChanged.AddListener(ChangeToggleIcon);
    }

    private void ChangeToggleIcon(bool toggled)
    {
        _toggleSprite.sprite = toggled? _toggledSprite: _untoggledSprite;
    }
}
