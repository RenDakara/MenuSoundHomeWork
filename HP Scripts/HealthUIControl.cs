using TMPro;
using UnityEngine;

public class HealthUIControl : HealthUIParent
{
    [SerializeField] private TextMeshProUGUI _text;

    protected override void UpdateUI()
    {
        if (_text != null && _health != null)
        {
            _text.text = $"���� �������� {_health.Max} ||| �������� {_health.Current}";
        }
    }

    public void ShowHealth()
    {
        UpdateUI();
    }
}
