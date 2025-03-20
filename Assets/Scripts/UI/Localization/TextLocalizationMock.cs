using TMPro;
using UnityEngine;

public class TextLocalizationMock : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private TMP_Text _localizableText;

    [Header("Localization parameters")]
    [SerializeField] private string _textKey;

    private void Start()
    {
        LocalizeText();
    }

    public void LocalizeText()
    {
        // var localizedString = LocalizationService.GetLocalizedString(_textKey);
        // _localizableText.text = localizedString;
    }
}

