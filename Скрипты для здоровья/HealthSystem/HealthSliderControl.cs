using UnityEngine.UI;
using UnityEngine;

public class HealthSliderControl : MonoBehaviour
{
    [SerializeField] private Slider _healthSlider;
    [SerializeField] private Slider _healthSlider2;
    private Health _health;

    private float _smoothSpeed = 10f;
    private float _displayedHealth;

    private void Awake()
    {
        _health = GetComponent<Health>();
        if (_healthSlider != null && _healthSlider2 != null)
        {
            _healthSlider.maxValue = _health.MaxHealth;
            _healthSlider2.maxValue = _health.MaxHealth;
            _healthSlider.value = _health.CurrentHealth;
            _displayedHealth = _health.CurrentHealth;
            _healthSlider2.value = _displayedHealth;
        }

        _health.OnHealthChanged += UpdateSlider;
    }

    private void Update()
    {
        if (_healthSlider2 != null)
        {
            _displayedHealth = Mathf.MoveTowards(_displayedHealth, _health.CurrentHealth, _smoothSpeed * Time.deltaTime);
            _healthSlider2.value = _displayedHealth;
        }
    }

    private void OnDestroy()
    {
        if (_health != null)
            _health.OnHealthChanged -= UpdateSlider;
    }

    private void UpdateSlider()
    {
        if (_healthSlider != null && _health != null)
        {
            _healthSlider.value = _health.CurrentHealth;
        }
    }
}
