using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float _currentHealthAmount = 100f;

    public event Action HealthChanged;

    private float _maxHealth = 100f;
    private float _minHealth = 0f;
    private float _currentHealth = 50;

    public float CurrentHealth => _currentHealth;
    public float MaxHealth => _maxHealth;

    private void Awake()
    {
        _currentHealth = _maxHealth;
    }

    public void Heal(float amount)
    {
        if (amount >= 0)
        {
            _currentHealth += amount;
            _currentHealth = Mathf.Min(_currentHealth, _maxHealth);
            HealthChanged?.Invoke();
        }
    }

    public void TakeDamage(float damage)
    {
        if (damage >= 0)
        {
            _currentHealth -= damage;
            _currentHealth = Mathf.Max(_currentHealth, _minHealth);
            HealthChanged?.Invoke();
        }

        if (_currentHealth <= _minHealth)
            Die();
    }

    public void ShowInfo()
    {
        Debug.Log(_currentHealth);
    }

    private void Die()
    {
        Destroy(this.gameObject);
    }
}
