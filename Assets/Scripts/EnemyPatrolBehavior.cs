using UnityEngine;

public class EnemyPatrolBehavior : MonoBehaviour
{
    [SerializeField] private Waypoint _pointA;
    [SerializeField] private Waypoint _pointB;
    [SerializeField] private float _speed = 1f;

    private bool _isPlayerNear = false;
    private float _distanceToWaypoint = 0.5f;
    private Transform _currentWaypointToGo;
    private Transform _playerPosition;
    private Rigidbody2D _rigidbody;

    private void FixedUpdate()
    {
        if (_isPlayerNear)
        {
            Chase();
        }
        else
        {
            Patrol();
        }
    }

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _currentWaypointToGo = _pointA.transform;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent(out Player player))
        {
            _isPlayerNear = true;
            _playerPosition = player.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        _isPlayerNear = false;
    }

    private void Chase()
    {
        float directionChanger = -1f;
        Vector2 point = _playerPosition.position - transform.position;

        if (_playerPosition.position.x > transform.position.x)
        {
            _rigidbody.velocity = new Vector2(_speed, 0);
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else
        {
            _rigidbody.velocity = new Vector2(_speed * directionChanger, 0);
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }

    private void Patrol()
    {
        float directionChanger = -1f;
        Vector2 point = _currentWaypointToGo.position - transform.position;

        if (_currentWaypointToGo == _pointB.transform)
        {
            _rigidbody.velocity = new Vector2(_speed, 0);
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else
        {
            _rigidbody.velocity = new Vector2(_speed * directionChanger, 0);
            transform.localScale = new Vector3(1f, 1f, 1f);
        }

        if ((transform.position - _currentWaypointToGo.position).sqrMagnitude < _distanceToWaypoint * _distanceToWaypoint)
        {
            _currentWaypointToGo = _currentWaypointToGo == _pointB.transform ? _pointA.transform : _pointB.transform;
        }
    }
}
