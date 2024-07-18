using UnityEngine;
using UnityEngine.UI;

public class IconSwitcher : MonoBehaviour
{
    [SerializeField] private Sprite _iconOn;
    [SerializeField] private Sprite _iconOff;

    private Image _button;

    private void Awake()
    {
        _button = GetComponent<Image>();
    }

    public void Switch()
    {
        if (_button.sprite == _iconOn)
        {
            _button.sprite = _iconOff;
        }
        else
        {
            _button.sprite = _iconOn;
        }
    }
}
