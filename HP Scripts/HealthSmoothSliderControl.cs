using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HealthSmoothSlider : HealthDisplayBase
{
    [SerializeField] private Slider _slider;
    private float _smoothSpeed = 10f;
    private float _displayedHealth;

    protected override void Initialize()
    {
        if (_slider != null)
        {
            _slider.maxValue = _health.Max;
            _displayedHealth = _health.Current;
            _slider.value = _displayedHealth;
        }
    }

    protected override void OnHealthChanged()
    {
        base.OnHealthChanged();
        StopAllCoroutines();
        StartCoroutine(AnimateSlider());
    }

    private IEnumerator AnimateSlider()
    {
        while (Mathf.Abs(_displayedHealth - _health.Current) > 0.01f)
        {
            _displayedHealth = Mathf.MoveTowards(_displayedHealth, _health.Current, _smoothSpeed * Time.deltaTime);
            if (_slider != null)
                _slider.value = _displayedHealth;
            yield return null;
        }

        if (_slider != null)
            _slider.value = _health.Current;

        UpdateUI();
    }

    protected override void UpdateUI() { } 
}
