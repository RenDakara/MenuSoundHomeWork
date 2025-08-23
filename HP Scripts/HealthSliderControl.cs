using UnityEngine.UI;
using UnityEngine;

public class HealthSlider : HealthDisplayBase
{
    [SerializeField] private Slider _slider;

    protected override void Initialize()
    {
        if (_slider != null)
        {
            _slider.maxValue = _health.Max;
            _slider.value = _health.Current;
        }
    }

    protected override void UpdateUI()
    {
        if (_slider != null)
            _slider.value = _health.Current;
    }
}
