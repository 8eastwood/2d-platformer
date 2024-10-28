using UnityEngine;

[RequireComponent(typeof(EnemyPatrolBehavior))]
[RequireComponent(typeof(BoxCollider2D))]
public class PlayerDetector : MonoBehaviour
{
    private Transform _playerPosition;
    private EnemyPatrolBehavior _enemyBehavior;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent(out Player player))
        {
            _enemyBehavior.PlayerNear();
            _enemyBehavior.GetPlayerPosition(player.transform);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        _enemyBehavior.PlayerNear();
    }
}
