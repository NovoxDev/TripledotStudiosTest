using UnityEngine;
using UnityEngine.UI;

public class BackgroundScaler : MonoBehaviour
{
    [SerializeField] private AspectRatioFitter _aspectRatioFitter;
    [SerializeField] private Image _background;

    private void Start()
    {
        FitToScreen();
    }

    void FitToScreen()
    {
        float imageRatio = _background.sprite.bounds.size.x / _background.sprite.bounds.size.y;
        _aspectRatioFitter.aspectRatio = imageRatio;
    }
}
