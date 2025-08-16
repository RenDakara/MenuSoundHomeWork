using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float _healthAmount = 100f;

    public event Action OnHealthChanged;

    private float _maxHealth = 100f;
    private float _minHealth = 0f;
    private float _health = 50;

    public float CurrentHealth => _health;
    public float MaxHealth => _maxHealth;

    private void Awake()
    {
        _health = _maxHealth;
    }

    public void Heal(float amount)
    {
        _health += amount;
        _health = Mathf.Min(_health, _maxHealth);
        OnHealthChanged?.Invoke();
    }

    public void TakeDamage(float damage)
    {
        _health -= damage;       
        _health = Mathf.Max(_health, _minHealth);
        OnHealthChanged?.Invoke();

        if(_health <= _minHealth)       
            Die();       
    }

    public void ShowInfo()
    {
        Debug.Log(_health);
    }

    private void Die()
    {
        Destroy(this.gameObject);
    }
}
