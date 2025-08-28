using UnityEngine;

public class ButtonFunc : MonoBehaviour
{
    public GameObject playerObject;
    private Health _health;

    private void Awake()
    {
            _health = playerObject.GetComponent<Health>();
    }

    public void Heal()
    {
            _health.Heal(5);
    }

    public void TakeDamage()
    {
            _health.TakeDamage(5);
    }
}
