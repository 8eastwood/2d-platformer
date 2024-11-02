using UnityEngine;

[RequireComponent(typeof(EnemyPatrolBehavior))]
[RequireComponent(typeof(BoxCollider2D))]
public class PlayerDetector : MonoBehaviour
{
    [SerializeField] private Player _player;

    public bool IsPlayerNear { get; private set; } = false;
    public Transform _playerPosition { get; private set; }

    private Transform TransferPlayerPosition(Transform playerPosition)
    {
        return playerPosition;
    }

    private bool DetectPlayerNear()
    {
        IsPlayerNear = true;

        return IsPlayerNear;
    }

    private bool DetectPlayerLeft()
    {
        IsPlayerNear = false;

        return IsPlayerNear;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent(out Player player))
        {
            Debug.Log("игрок в поле зрения");
            DetectPlayerNear();
            _playerPosition = TransferPlayerPosition(_player.transform);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        DetectPlayerLeft();
    }
}
