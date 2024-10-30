using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int _maxAmount;

    public int CurrentAmount { get; private set; }

    private void Awake()
    {
        CurrentAmount = _maxAmount;
    }

    public void TakeHeal(int healPoints)
    {
        CurrentAmount += healPoints;
        Debug.Log("вылечено " + healPoints + " хп");
    }

    public void TakeDamage(int damage)
    {
        CurrentAmount -= damage;

        if (CurrentAmount < 0)
        {
            CurrentAmount = 0;
            Die();
        }
    }

    private void Die()
    {
        enabled = false;
        Destroy(gameObject);
    }
}
