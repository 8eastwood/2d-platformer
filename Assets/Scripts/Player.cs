using UnityEngine;

[RequireComponent(typeof(Player))]
[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Rigidbody2D))]

public class Player : MonoBehaviour
{
    private PlayerCombat _combat;
    private bool _isAttack;
    private Health _health;
    private string _name = "Player";

    public Player()
    {
        Name = _name;
    }

    public string Name { get; private set; }


    private void Awake()
    {
        _health = GetComponent<Health>();
        _combat = GetComponent<PlayerCombat>();
    }

    public void Heal()
    {
        _health.TakeHeal();
    }

    public void TakeDamage(int damage)
    {
        Debug.Log("player got hit and have " + _health.ShowHealth() + "HP ");
        _health.TakeDamage(damage, Name);
    }
}
