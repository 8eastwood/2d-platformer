using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    [SerializeField] private Transform _attackPoint;

    private int _attackDamage = 20;
    private float _attackRange = 1f;
    private bool _isAttack;

    //public void Attack()
    //{
    //    Collider2D[] _hittedEnemies = Physics2D.OverlapCircleAll(_attackPoint.position, _attackRange, _enemyLayers);

    //    foreach (Collider2D enemy in _hittedEnemies)
    //    {
    //        Debug.Log("Hit enemy " + enemy.name);
    //        enemy.GetComponent<Enemy>().TakeDamage(_attackDamage);
    //    }
    //}

    //private void Update()
    //{
    //    _isAttack = Input.GetKeyDown(KeyCode.E);
    //}

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Enemy enemy) && Input.GetKeyDown(KeyCode.E))
        {
            Attack(enemy);
            Debug.Log("Player hit enemy");
        }
    }

    public void Attack(Enemy enemy)
    {
        enemy.TakeDamage(_attackDamage);
    }

    private void OnDrawGizmosSelected()
    {
        if (_attackPoint == null)
        {
            return;
        }
        else
        {
            Gizmos.DrawWireSphere(_attackPoint.position, _attackRange);
        }
    }
}
