using UnityEngine;
using System.Collections;

public abstract class HealthDisplayBase : MonoBehaviour
{
    protected Health _health;

    protected virtual void Awake()
    {
        _health = GetComponent<Health>();

        _health.HealthChanged += OnHealthChanged;

        Initialize();
        UpdateUI();
    }

    protected virtual void OnDestroy()
    {
        if (_health != null)
            _health.HealthChanged -= OnHealthChanged;
    }

    protected virtual void OnHealthChanged()
    {
        UpdateUI();
    }

    protected abstract void Initialize();
    protected abstract void UpdateUI();
}
