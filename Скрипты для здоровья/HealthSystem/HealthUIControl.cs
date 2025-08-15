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
            Debug.Log("Вывожу сообщение" + _health.CurrentHealth);
            _text.text = "Макс здоровье" + " " + _health.MaxHealth + "|||" + "Здоровье" + " " + _health.CurrentHealth;
        }
    }
}
