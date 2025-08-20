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
        Debug.Log("������ ���������" + _health.CurrentHealth);
        _text.text = "���� ��������" + " " + _health.MaxHealth + "|||" + "��������" + " " + _health.CurrentHealth;
    }
}
