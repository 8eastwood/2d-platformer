using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Waypoint _pointA;
    [SerializeField] private Waypoint _pointB;
    [SerializeField] private float _speed = 1f;
    [SerializeField] private Player _player;

    public readonly int isRunning = Animator.StringToHash(nameof(isRunning));
    public Animator Animator;
    private Rigidbody2D _rigidbody;
    private Transform _currentWaypointToGo;
    private float _distanceToWaypoint = 0.5f;
    private bool _isPlayerNear = false;
    private Transform _playerPosition;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _currentWaypointToGo = _pointA.transform;
        Animator.SetBool(isRunning, true);
    }

    private void Update()
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent(out Player player))
        {
            _isPlayerNear = true;
            _playerPosition = player.transform;
        }
        else
        {
            _isPlayerNear = false;
        }
    }

    private void Attack()
    {

    }

    private void Chase()
    {
        float directionChanger = -1f;
        Vector2 point = _playerPosition.position - transform.position;

        if (_playerPosition.position.x > transform.position.x)
        {
            _rigidbody.velocity = new Vector2(_speed , 0);
        }
        else
        {
            _rigidbody.velocity = new Vector2(_speed * directionChanger, 0);
        }
    }

    private void Patrol()
    {
        float directionChanger = -1f;
        Vector2 point = _currentWaypointToGo.position - transform.position;

        if (_currentWaypointToGo == _pointB.transform)
        {
            _rigidbody.velocity = new Vector2(_speed, 0);
        }
        else
        {
            _rigidbody.velocity = new Vector2(_speed * directionChanger, 0);
        }

        if ((transform.position - _currentWaypointToGo.position).sqrMagnitude < _distanceToWaypoint * _distanceToWaypoint)
        {
            FlipSide(directionChanger);
            _currentWaypointToGo = _currentWaypointToGo == _pointB.transform ? _pointA.transform : _pointB.transform;
        }
    }

    private void FlipSide(float sideChanger)
    {
        
        Vector3 localScale = transform.localScale;
        localScale.x *= sideChanger;
        transform.localScale = localScale;
    }
}
