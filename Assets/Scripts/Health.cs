using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int _maxHealth;

    private int _currentHealth;

    private void Awake()
    {
        _currentHealth = _maxHealth;
    }

    public void TakeHeal()
    {
        int HealthAmountToHeal = 50;
        _currentHealth += HealthAmountToHeal;
    }

    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;

        if (_currentHealth < 0)
        {
            _currentHealth = 0;
            Die();
        }
    }

    public int ShowHealth()
    {
        return _currentHealth;
    }

    private void Die()
    {
        enabled = false;
        Destroy(gameObject);
    }
}
