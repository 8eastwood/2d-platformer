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
        Debug.Log(_currentHealth + "before heal");
        int HealthAmountToHeal = 50;
        _currentHealth += HealthAmountToHeal;
        Debug.Log(_currentHealth + "after heal");
    }

    public void TakeDamage(int damage, string name)
    {
        _currentHealth -= damage;

        if (_currentHealth < 0)
        {
            _currentHealth = 0;
            Die(name);
        }
    }

    public int ShowHealth()
    {
        return _currentHealth;
    }

    private void Die(string name)
    {
        Debug.Log(name + " died!");
        this.enabled = false;
        Destroy(gameObject);
    }
}
