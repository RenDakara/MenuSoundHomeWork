using UnityEngine;
using UnityEngine.UI;

public class HealthSlider : HealthUIParent
{
    [SerializeField] private Slider _slider;

    protected override void Initialize()
    {
        if (_slider != null && _health != null)
        {
            _slider.maxValue = _health.Max;
            _slider.value = _health.Current;
        }
    }

    protected override void UpdateUI()
    {
        if (_slider != null && _health != null)
            _slider.value = _health.Current;
    }
}
