using UnityEngine;

public class EnemyCombat : MonoBehaviour
{
    [SerializeField] private Transform _enemyAttackPoint;
    [SerializeField] private bool _isAttackEnabled;

    private int _enemyAttackDamage = 1;
    //private float _attackRange = 1f;

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent(out Player player) && _isAttackEnabled)
        {
            Attack(player);
        }
    }

    private void Attack(Player player)
    {
        player.TakeDamage(_enemyAttackDamage);
    }
}
