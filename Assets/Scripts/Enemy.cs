using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Animator Animator;

    private readonly int isRunning = Animator.StringToHash(nameof(isRunning));
    private Health _health;
    private int _damageToTake;

    private void Awake()
    {
        _health = GetComponent<Health>();
        Animator.SetBool(isRunning, true);
    }

    public void TakeDamage(int damage)
    {
        _health.TakeDamage(damage);
    }
}
