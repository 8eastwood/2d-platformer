using UnityEngine;

[RequireComponent(typeof(Player))]
[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Rigidbody2D))]

public class Player : MonoBehaviour
{
    private bool _isAttack;
    private Health _health;

    private void Awake()
    {
        _health = GetComponent<Health>();
    }

    public void Heal()
    {
        _health.TakeHeal();
    }

    public void TakeDamage(int damage)
    {
        _health.TakeDamage(damage);
    }


}
