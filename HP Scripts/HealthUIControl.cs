using TMPro;
using UnityEngine;
[RequireComponent(typeof(Health))]

public class HealthUIControl : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    private Health _health;

    private void Awake()
    {
        _health = GetComponent<Health>();

        _health.HealthChanged += ShowHealth;

        ShowHealth();
    }

    private void OnDestroy()
    {
        _health.HealthChanged -= ShowHealth;
    }

    public void ShowHealth()
    {
        Debug.Log("Вывожу сообщение" + _health.CurrentHealth);
        _text.text = "Макс здоровье" + " " + _health.MaxHealth + "|||" + "Здоровье" + " " + _health.CurrentHealth;
    }
}
