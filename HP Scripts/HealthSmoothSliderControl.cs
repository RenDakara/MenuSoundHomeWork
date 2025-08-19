using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSmoothSliderControl : MonoBehaviour
{
    [SerializeField] private Slider _healthSlider;
    private Health _health;

    private float _smoothSpeed = 10f;
    private float _displayedHealth;

    private void Awake()
    {
        _health = GetComponent<Health>();

        _healthSlider.maxValue = _health.MaxHealth;
        _displayedHealth = _health.CurrentHealth;
        _healthSlider.value = _displayedHealth;

        _health.HealthChanged += SetHealth;
    }

    private void OnDestroy()
    {
        _health.HealthChanged -= SetHealth;
    }

    public void SetHealth()
    {
        StopAllCoroutines();
        StartCoroutine(AnimateSlider());
    }

    private IEnumerator AnimateSlider()
    {
        while (Mathf.Abs(_displayedHealth - _health.MaxHealth) > 0.01f)
        {
            _displayedHealth = Mathf.MoveTowards(_displayedHealth, _health.CurrentHealth, _smoothSpeed * Time.deltaTime);
            _healthSlider.value = _displayedHealth;
            yield return null;
        }

    }
}
