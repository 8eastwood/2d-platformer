using UnityEngine;

[RequireComponent(typeof(EnemyPatrolBehavior))]
[RequireComponent(typeof(BoxCollider2D))]
public class PlayerDetector : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private EnemyPatrolBehavior _enemyBehavior;
    public bool _isPlayerNear { get; private set; } = false;
    public Vector3 _playerPosition { get; private set; }

    private Vector3 TransferPlayerPosition(Vector3 playerPosition)
    {
        return playerPosition;
    }

    private bool DetectPlayerNear(bool isPlayerNear)
    {
        return true;
    }

    private bool DetectPlayerLeft(bool isPlayerNear)
    {
        return false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent(out Player player))
        {
            Debug.Log("игрок в поле зрения");
            DetectPlayerNear(_enemyBehavior.IsPlayerNear);
            _playerPosition = TransferPlayerPosition(_player.transform.position);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        DetectPlayerLeft(_enemyBehavior.IsPlayerNear);
    }
}
