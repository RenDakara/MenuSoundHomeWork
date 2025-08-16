using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthUIControl : MonoBehaviour
{
    private Health _health;
    [SerializeField] private TextMeshProUGUI _text;
    

    private void Awake()
    {
        _health = GetComponent<Health>();
        if (_health != null)
            _health.OnHealthChanged += ShowHealth;

        ShowHealth();
    }

    private void OnDestroy()
    {
        if( _health != null )
            _health.OnHealthChanged -= ShowHealth;
    }

    public void ShowHealth()
    {
        if (_health != null)
        {
            Debug.Log("������ ���������" + _health.CurrentHealth);
            _text.text = "���� ��������" + " " + _health.MaxHealth + "|||" + "��������" + " " + _health.CurrentHealth;
        }
    }
}
