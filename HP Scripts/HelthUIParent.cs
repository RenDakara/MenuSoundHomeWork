using UnityEngine;

[RequireComponent(typeof(Health))]
public abstract class HealthUIParent : MonoBehaviour
{
    protected Health _health;

    private void Awake()
    {
        _health = GetComponent<Health>();

        _health.HealthChanged += OnHealthChanged;

        Initialize();
        UpdateUI();
    }

    private void OnDestroy()
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
