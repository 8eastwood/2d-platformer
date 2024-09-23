using UnityEngine;

public class Enemy : MonoBehaviour
{
    public readonly int isRunning = Animator.StringToHash(nameof(isRunning));
    public Animator Animator;
    private Health _health;
    private string _name = "Enemy";

    public Enemy()
    {
        Name = _name;
    }

    public string Name { get; private set; }

    private void Awake()
    {
        _health = GetComponent<Health>();
        Animator.SetBool(isRunning, true);
    }

    public void TakeDamage(int damage)
    {
        _health.TakeDamage(damage, Name);
        Debug.Log("enemy got hit and have " + _health.ShowHealth() + "HP ");
    }

    public void Heal()
    {
        _health.TakeHeal();
    }
}
