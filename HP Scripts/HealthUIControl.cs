using TMPro;
using UnityEngine;

public class HealthUIControl : HealthDisplayBase
{
    [SerializeField] private TextMeshProUGUI _text;

    protected override void Initialize() { }

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
