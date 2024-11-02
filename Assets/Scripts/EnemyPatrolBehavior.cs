using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyPatrolBehavior : MonoBehaviour
{
    [SerializeField] private Waypoint _pointA;
    [SerializeField] private Waypoint _pointB;
    [SerializeField] private float _speed = 1f;
    [SerializeField] private PlayerDetector _playerDetector;

    private float _distanceToWaypoint = 0.5f;
    private Transform _currentWaypointToGo;
    private Transform _playerPosition;
    private Rigidbody2D _rigidbody;
    private bool _isPlayerNear = false;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _currentWaypointToGo = _pointA.transform;
    }

    private void FixedUpdate()
    {
        _isPlayerNear = _playerDetector.IsPlayerNear;

        if (_isPlayerNear)
        {
            _playerPosition.transform.position = _playerDetector._playerPosition.transform.position;
            Chase();
        }
        else
        {
            Patrol();
        }
    }

    private void Chase()
    {
        float directionChanger = -1f;
        Vector2 point = _playerPosition.transform.position - transform.position;

        if (_playerPosition.transform.position.x > transform.position.x)
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
