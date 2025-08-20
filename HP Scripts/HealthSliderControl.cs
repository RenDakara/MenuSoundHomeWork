using UnityEngine.UI;
using UnityEngine;
[RequireComponent(typeof(Health))]

public class HealthSliderControl : MonoBehaviour
{
    [SerializeField] private Slider _healthSlider;

    private Health _health;

    private void Awake()
    {
        _health = GetComponent<Health>();

        _healthSlider.maxValue = _health.MaxHealth;
        _healthSlider.value = _health.CurrentHealth;

        _health.HealthChanged += UpdateSlider;
    }

    private void OnDestroy()
    {
        _health.HealthChanged -= UpdateSlider;
    }

    private void UpdateSlider()
    {
        _healthSlider.value = _health.CurrentHealth;
    }
}
