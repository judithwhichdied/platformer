using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class AbilityView : MonoBehaviour
{
    [SerializeField] private AbilityCaster _ability;

    [SerializeField] private TextMeshProUGUI _abilityText;

    private Image _abilityIcon;

    private float _delay = 1f;

    private WaitForSeconds _wait => new WaitForSeconds(_delay);

    private float _duration => _ability.Duration;
    private float _coolDown => _ability.CoolDown;

    private void Awake()
    {
        _abilityIcon = GetComponent<Image>();
    }

    private void OnEnable()
    {
        _ability.OnCoolDown += ShowCoolDown;
        //_ability.IsActive += ShowCoolDown;
    }

    private void OnDisable()
    {
        _ability.OnCoolDown -= ShowCoolDown;
        //_ability.IsActive -= ShowCoolDown;
    }

    private void ShowCoolDown()
    {
        StartCoroutine(nameof(StartCoolDown));
    }
   
    private IEnumerator StartCoolDown()
    {
        for (float i = _duration; i > 0; i--)
        {
            _abilityText.text = $"{i}";

            yield return _wait;
        }

        _abilityText.text = null;

        StartCoroutine(nameof(Ready));
    }

    private IEnumerator Ready()
    {
        float delay = 0.4f;

        WaitForSeconds wait = new WaitForSeconds(delay);

        Color alphaOff = new Color(1, 1, 1, 0);
        Color alphaOn = new Color(1, 1, 1, 1);

        while (_ability.CanActivate)
        {
            _abilityIcon.color = alphaOff;

            yield return wait;

            _abilityIcon.color = alphaOn;
        }
    }
}