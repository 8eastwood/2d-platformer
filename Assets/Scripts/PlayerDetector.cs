using UnityEngine;

[RequireComponent(typeof(EnemyPatrolBehavior))]
[RequireComponent(typeof(BoxCollider2D))]
public class PlayerDetector : MonoBehaviour
{
    [SerializeField] private EnemyPatrolBehavior _enemyBehavior;

    private Transform _playerPosition;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent(out Player player))
        {
            _enemyBehavior.DetectPlayerNear();
            _enemyBehavior.TransferPlayerPosition(player.transform);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        _enemyBehavior.DetectPlayerNear();
    }
}
